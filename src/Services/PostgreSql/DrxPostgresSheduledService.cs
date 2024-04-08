// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.
using Microsoft.Extensions.Logging;
using Npgsql;
using ParusRx.DirectumRx.Models;

namespace ParusRx.DirectumRx.Services.PostgreSql;

/// <summary>
/// Default credentials store.
/// </summary>
/// <seealso cref="IDrxSheduledService"/>

public class DrxPostgresSheduledService : IDrxSheduledService
{
    private readonly ILogger<DrxPostgresSheduledService> _logger;
    private readonly IDrxPartyService _drxPartyService;

    /// <summary>
    /// Initializes a new instance of the <see cref="DrxPostgresSheduledService"/> class.
    /// </summary>
    /// <param name="connection">The connection on database.</param>
    /// <param name="logger">The logger to use.</param>
    public DrxPostgresSheduledService(IConnection connection, ILogger<DrxPostgresSheduledService> logger, IDrxPartyService drxPartyService)
    {
        Connection = connection;
        _logger = logger;
        _drxPartyService = drxPartyService;
    }

    /// <summary>
    /// The <see cref="IConnection"/>.
    /// </summary>
    public IConnection Connection { get; }

    /// <inheritdoc/>
    public async Task<string> GetExecuteStateAsync(PackagesLifeCycle packagesLifeCycle)
    {
        try
        {
            using var connection = (NpgsqlConnection)Connection.ConnectionFactory.CreateConnection();
            await connection.OpenAsync();

            using var transaction = connection.BeginTransaction();

            using var command = new NpgsqlCommand("SELECT parus.p_drxedmjr_pck_life_cycle(@bcontent)", connection, transaction);

            command.Parameters.AddWithValue("bcontent", XmlSerializerUtility.Serialize(packagesLifeCycle));

            await command.ExecuteNonQueryAsync();

            await transaction.CommitAsync();

            return "Ok";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while performing the process of obtaining the document state.");
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<string> GetExchangeQueueItemAsync(AuthorizationDrxEQI authorizationDrxEQI, DrxExchangeQueueItems exchangeQueueItems)
    {
        try
        {
            var connection = (NpgsqlConnection)Connection.ConnectionFactory.CreateConnection();
            connection.Open();

            var transaction = connection.BeginTransaction();

            foreach (var exchangeQueueItem in exchangeQueueItems.ExchangeQueueItems)
            {
                var docMain = exchangeQueueItem.Attacheds.First(x => x.Main == 1);

                /// Добавление записи в Журнал взаимодействия
                using var drxedmjr = new NpgsqlCommand("SELECT parus.p_drxexchange_queue(@ncompany, @njur_pers, @ndrxconnect, @ndrxcompany, @scode, @stin, @strrc, @nemployee_id, @nbusinessunit_id, @sdescription, @siastate, @seastate, @slcstate, @snote)", connection);

                drxedmjr.Parameters.AddWithValue("ncompany", authorizationDrxEQI.Company);
                drxedmjr.Parameters.AddWithValue("njur_pers", authorizationDrxEQI.Jurpers);
                drxedmjr.Parameters.AddWithValue("ndrxconnect", authorizationDrxEQI.ConnectRn);
                drxedmjr.Parameters.AddWithValue("ndrxcompany", authorizationDrxEQI.BusinessUnitRn);
                drxedmjr.Parameters.AddWithValue("scode", "DRXEDMJournal");
                drxedmjr.Parameters.AddWithValue("stin", exchangeQueueItem.CounterpartyTIN.Any() ? exchangeQueueItem.CounterpartyTIN : string.Empty);
                drxedmjr.Parameters.AddWithValue("strrc", exchangeQueueItem.CounterpartyTRRC.Any() ? exchangeQueueItem.CounterpartyTRRC : string.Empty);
                drxedmjr.Parameters.AddWithValue("nemployee_id", exchangeQueueItem.EmployeeId);
                drxedmjr.Parameters.AddWithValue("nbusinessunit_id", authorizationDrxEQI.BusinessUnitId);
                drxedmjr.Parameters.AddWithValue("sdescription", exchangeQueueItem.Name);
                drxedmjr.Parameters.AddWithValue("siastate", string.IsNullOrEmpty(docMain.InternalApprovalState) ? "None" : docMain.InternalApprovalState);
                drxedmjr.Parameters.AddWithValue("seastate", string.IsNullOrEmpty(docMain.ExternalApprovalState) ? "None" : docMain.ExternalApprovalState);
                drxedmjr.Parameters.AddWithValue("slcstate", string.IsNullOrEmpty(docMain.LifeCycleState) ? "None" : docMain.LifeCycleState);
                drxedmjr.Parameters.AddWithValue("snote", string.IsNullOrWhiteSpace(exchangeQueueItem.Note) ? "Получен из системы  ЭДО DirectumRX." : exchangeQueueItem.Note);

                using var reader_drxedmjr = await drxedmjr.ExecuteReaderAsync();
                long nedmjr = 0;
                while (await reader_drxedmjr.ReadAsync())
                {
                    nedmjr = reader_drxedmjr.GetFieldValue<long>(0);
                }
                await reader_drxedmjr.CloseAsync();

                _logger.LogInformation("nedmjr = {0}", nedmjr);
                if (nedmjr != 0)
                {
                    /// Добавление вложенных документов в спецификацию журнала взаимодействия с DirectuRX
                    foreach (var attached in exchangeQueueItem.Attacheds)
                    {
                        _logger.LogInformation("attached = {0}", attached.Name);
                        /// Добавление записи в Журнал взаимодействия
                        var drxedmjrdoc = new NpgsqlCommand("SELECT parus.p_drxexchange_queue_doc(@ncompany, @ndrxconnect, @nedmjr, @ndoc_id, @ndoc_type_id, @ndoc_kind_id, @ndoc_ctg_id, @ndoc_reg_id, @sdescription, @nmain, @sstate, @siastate, @seastate, @sfile_name, @bfile_content, @snote, @surl_api)", connection);
                        //using var drxedmjrdoc = new NpgsqlCommand("SELECT parus.p_drxexchange_queue_doc(@ncompany)", connection);

                        drxedmjrdoc.Parameters.AddWithValue("ncompany", authorizationDrxEQI.Company);
                        drxedmjrdoc.Parameters.AddWithValue("ndrxconnect", authorizationDrxEQI.ConnectRn);
                        drxedmjrdoc.Parameters.AddWithValue("nedmjr", nedmjr);
                        drxedmjrdoc.Parameters.AddWithValue("ndoc_id", attached.Id);
                        drxedmjrdoc.Parameters.AddWithValue("ndoc_type_id", attached.DocumentTypeId);
                        drxedmjrdoc.Parameters.AddWithValue("ndoc_kind_id", attached.DocumentKindId);
                        drxedmjrdoc.Parameters.AddWithValue("ndoc_ctg_id", attached.DocumentGroupId.HasValue ? attached.DocumentGroupId.Value : DBNull.Value);
                        drxedmjrdoc.Parameters.AddWithValue("ndoc_reg_id", attached.DocumentRegisterId.HasValue ? attached.DocumentRegisterId.Value : DBNull.Value);
                        drxedmjrdoc.Parameters.AddWithValue("sdescription", attached.Name);
                        drxedmjrdoc.Parameters.AddWithValue("nmain", Convert.ToInt64(attached.Main));
                        drxedmjrdoc.Parameters.AddWithValue("sstate", string.IsNullOrEmpty(attached.LifeCycleState) ? "None" : attached.LifeCycleState);
                        drxedmjrdoc.Parameters.AddWithValue("siastate", string.IsNullOrEmpty(attached.InternalApprovalState) ? "None" : attached.InternalApprovalState);
                        drxedmjrdoc.Parameters.AddWithValue("seastate", string.IsNullOrEmpty(attached.ExternalApprovalState) ? "None" : attached.ExternalApprovalState);
                        drxedmjrdoc.Parameters.AddWithValue("sfile_name", attached.Name);
                        drxedmjrdoc.Parameters.AddWithValue("bfile_content", attached.Body);
                        drxedmjrdoc.Parameters.AddWithValue("snote", string.IsNullOrWhiteSpace(attached.Note) ? "Получен из системы  ЭДО DirectumRX." : attached.Note);
                        drxedmjrdoc.Parameters.AddWithValue("surl_api", attached.Link);

                        using var reader_drxedmjrdoc = await drxedmjrdoc.ExecuteReaderAsync();
                        {
                            long nedmjrdoc = 0;
                            while (await reader_drxedmjrdoc.ReadAsync())
                            {
                                nedmjrdoc = reader_drxedmjrdoc.GetFieldValue<long>(0);
                                _logger.LogInformation("nedmjrdoc = {0}", nedmjrdoc);
                            }
                        }
                    }
                }

                await _drxPartyService.PostExchangeQueueItemAsync(authorizationDrxEQI, exchangeQueueItem.Id, nedmjr);
            }

            await transaction.CommitAsync();
            return "Ok";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while performing the process of obtaining the ."); // <------------
            throw;
        }

    }
}
