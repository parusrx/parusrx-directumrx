// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.ComponentModel.Design;
using System.Xml;
using Microsoft.Extensions.Logging;
using ParusRx.DirectumRx.Models;

namespace ParusRx.DirectumRx.Services.Oracle;

/// <summary>
/// Default credentials store.
/// </summary>
/// <seealso cref="IDrxSheduledService"/>

public class DrxOracleSheduledService : IDrxSheduledService
{
    private readonly IConnection _connection;
    private readonly ILogger<DrxOracleSheduledService> _logger;
    private readonly IDrxPartyService _drxPartyService;

    /// <summary>
    /// Initializes a new instance of the <see cref="DrxOracleSheduledService"/> class.
    /// </summary>
    /// <param name="connection">The connection on database.</param>
    /// <param name="logger">The logger to use.</param>
    public DrxOracleSheduledService(IConnection connection, ILogger<DrxOracleSheduledService> logger, IDrxPartyService drxPartyService)
    {
        _connection = connection;
        _logger = logger;
        _drxPartyService = drxPartyService;
    }

    /// <inheritdoc/>
    public async Task<string> GetExecuteStateAsync(PackagesLifeCycle packagesLifeCycle)
    {
        try
        {
            using var connection = _connection.ConnectionFactory.CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            var cmd = new OracleCommand

            {
                Connection = (OracleConnection)connection,
                CommandType = CommandType.StoredProcedure,
                Transaction = (OracleTransaction)transaction,
                CommandText = "parus.p_drxedmjr_pck_life_cycle"
            };

            var paramConnect = cmd.CreateParameter();
            paramConnect.OracleDbType = OracleDbType.Blob;
            paramConnect.Direction = ParameterDirection.Input;
            paramConnect.ParameterName = "bcontent";
            paramConnect.Value = XmlSerializerUtility.Serialize(packagesLifeCycle);
            cmd.Parameters.Add(paramConnect);

            cmd.ExecuteNonQuery();

            transaction.Commit();
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
            using var connection = _connection.ConnectionFactory.CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();
            foreach (var exchangeQueueItem in exchangeQueueItems.ExchangeQueueItems)
            {

                var docMain = exchangeQueueItem.Attacheds.First(x => x.Main == 1);

                var cmdEDMJR = new OracleCommand
                {
                    Connection = (OracleConnection)connection,
                    CommandType = CommandType.StoredProcedure,
                    Transaction = (OracleTransaction)transaction,
                    CommandText = "parus.p_drxexchange_queue"
                };

                var paramEDMJR = cmdEDMJR.CreateParameter();
                paramEDMJR.OracleDbType = OracleDbType.Int64;
                paramEDMJR.Direction = ParameterDirection.Input;
                paramEDMJR.ParameterName = "ncompany";
                paramEDMJR.Value = authorizationDrxEQI.Company;
                cmdEDMJR.Parameters.Add(paramEDMJR);

                paramEDMJR = cmdEDMJR.CreateParameter();
                paramEDMJR.OracleDbType = OracleDbType.Int64;
                paramEDMJR.Direction = ParameterDirection.Input;
                paramEDMJR.ParameterName = "njur_pers";
                paramEDMJR.Value = authorizationDrxEQI.Jurpers;
                cmdEDMJR.Parameters.Add(paramEDMJR);

                paramEDMJR = cmdEDMJR.CreateParameter();
                paramEDMJR.OracleDbType = OracleDbType.Int64;
                paramEDMJR.Direction = ParameterDirection.Input;
                paramEDMJR.ParameterName = "ndrxconnect";
                paramEDMJR.Value = authorizationDrxEQI.ConnectRn;
                cmdEDMJR.Parameters.Add(paramEDMJR);

                paramEDMJR = cmdEDMJR.CreateParameter();
                paramEDMJR.OracleDbType = OracleDbType.Int64;
                paramEDMJR.Direction = ParameterDirection.Input;
                paramEDMJR.ParameterName = "ndrxcompany";
                paramEDMJR.Value = authorizationDrxEQI.BusinessUnitRn;
                cmdEDMJR.Parameters.Add(paramEDMJR);

                paramEDMJR = cmdEDMJR.CreateParameter();
                paramEDMJR.OracleDbType = OracleDbType.Varchar2;
                paramEDMJR.Direction = ParameterDirection.Input;
                paramEDMJR.ParameterName = "scode";
                paramEDMJR.Value = "DRXEDMJournal";
                cmdEDMJR.Parameters.Add(paramEDMJR);

                paramEDMJR = cmdEDMJR.CreateParameter();
                paramEDMJR.OracleDbType = OracleDbType.Varchar2;
                paramEDMJR.Direction = ParameterDirection.Input;
                paramEDMJR.ParameterName = "stin";
                if (exchangeQueueItem.CounterpartyTIN.Any())
                    paramEDMJR.Value = exchangeQueueItem.CounterpartyTIN;
                cmdEDMJR.Parameters.Add(paramEDMJR);

                paramEDMJR = cmdEDMJR.CreateParameter();
                paramEDMJR.OracleDbType = OracleDbType.Varchar2;
                paramEDMJR.Direction = ParameterDirection.Input;
                paramEDMJR.ParameterName = "strrc";
                if (exchangeQueueItem.CounterpartyTRRC.Any())
                    paramEDMJR.Value = exchangeQueueItem.CounterpartyTRRC;
                cmdEDMJR.Parameters.Add(paramEDMJR);

                paramEDMJR = cmdEDMJR.CreateParameter();
                paramEDMJR.OracleDbType = OracleDbType.Int64;
                paramEDMJR.Direction = ParameterDirection.Input;
                paramEDMJR.ParameterName = "nemployee_id";
                paramEDMJR.Value = exchangeQueueItem.EmployeeId;
                cmdEDMJR.Parameters.Add(paramEDMJR);

                paramEDMJR = cmdEDMJR.CreateParameter();
                paramEDMJR.OracleDbType = OracleDbType.Int64;
                paramEDMJR.Direction = ParameterDirection.Input;
                paramEDMJR.ParameterName = "nbusinessunit_id";
                paramEDMJR.Value = authorizationDrxEQI.BusinessUnitId;
                cmdEDMJR.Parameters.Add(paramEDMJR);

                paramEDMJR = cmdEDMJR.CreateParameter();
                paramEDMJR.OracleDbType = OracleDbType.Varchar2;
                paramEDMJR.Direction = ParameterDirection.Input;
                paramEDMJR.ParameterName = "sdescription";
                paramEDMJR.Value = exchangeQueueItem.Name;
                cmdEDMJR.Parameters.Add(paramEDMJR);

                paramEDMJR = cmdEDMJR.CreateParameter();
                paramEDMJR.OracleDbType = OracleDbType.Varchar2;
                paramEDMJR.Direction = ParameterDirection.Input;
                paramEDMJR.ParameterName = "siastate";
                paramEDMJR.Value = docMain.InternalApprovalState;
                cmdEDMJR.Parameters.Add(paramEDMJR);

                paramEDMJR = cmdEDMJR.CreateParameter();
                paramEDMJR.OracleDbType = OracleDbType.Varchar2;
                paramEDMJR.Direction = ParameterDirection.Input;
                paramEDMJR.ParameterName = "seastate";
                paramEDMJR.Value = docMain.ExternalApprovalState;
                cmdEDMJR.Parameters.Add(paramEDMJR);

                paramEDMJR = cmdEDMJR.CreateParameter();
                paramEDMJR.OracleDbType = OracleDbType.Varchar2;
                paramEDMJR.Direction = ParameterDirection.Input;
                paramEDMJR.ParameterName = "slcstate";
                paramEDMJR.Value = docMain.LastVersionApproved;
                cmdEDMJR.Parameters.Add(paramEDMJR);

                paramEDMJR = cmdEDMJR.CreateParameter();
                paramEDMJR.OracleDbType = OracleDbType.Varchar2;
                paramEDMJR.Direction = ParameterDirection.Input;
                paramEDMJR.ParameterName = "snote";
                paramEDMJR.Value = exchangeQueueItem.Note;
                cmdEDMJR.Parameters.Add(paramEDMJR);

                paramEDMJR = cmdEDMJR.CreateParameter();
                paramEDMJR.OracleDbType = OracleDbType.Int64;
                paramEDMJR.Direction = ParameterDirection.Output;
                paramEDMJR.ParameterName = "nedmjr";
                cmdEDMJR.Parameters.Add(paramEDMJR);

                cmdEDMJR.ExecuteNonQuery();

                if (long.TryParse(paramEDMJR.Value.ToString(), out var nEDMJR))
                {
                    //_logger.LogInformation(string.Format("nEDMJR = {0}", nEDMJR));
                    /// Добавление документов в спецификацию журнала взаимодействия с DirectuRX
                    foreach (var attached in exchangeQueueItem.Attacheds)
                    {
                        ///CreateEDMJRDocument(connection, transaction, authorizationDrxEQI, nEDMJR, attachment, 0);
                        var cmdEDMJRDoc = new OracleCommand
                        {
                            Connection = (OracleConnection)connection,
                            CommandType = CommandType.StoredProcedure,
                            Transaction = (OracleTransaction)transaction,
                            CommandText = "parus.p_drxexchange_queue_doc"
                        };

                        var paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Int64;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "ncompany";
                        paramDoc.Value = authorizationDrxEQI.Company;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Int64;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "ndrxconnect";
                        paramDoc.Value = authorizationDrxEQI.ConnectRn;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Int64;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "nedmjr";
                        paramDoc.Value = nEDMJR;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Int64;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "ndoc_id";
                        paramDoc.Value = attached.Id;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Int64;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "ndoc_type_id";
                        paramDoc.Value = attached.DocumentTypeId;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Int64;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "ndoc_kind_id";
                        paramDoc.Value = attached.DocumentKindId;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Int64;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "ndoc_ctg_id";
                        if (attached.DocumentGroupId.HasValue)
                            paramDoc.Value = attached.DocumentGroupId.Value;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Int64;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "ndoc_reg_id";
                        if (attached.DocumentRegisterId.HasValue)
                            paramDoc.Value = attached.DocumentRegisterId.Value;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Varchar2;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "sdescription";
                        paramDoc.Value = attached.Name;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Int64;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "nmain";
                        paramDoc.Value = Convert.ToInt64(attached.Main);
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Varchar2;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "sstate";
                        paramDoc.Value = string.IsNullOrEmpty(attached.LifeCycleState) ? "None" : attached.LifeCycleState;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Varchar2;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "siastate";
                        paramDoc.Value = string.IsNullOrEmpty(attached.InternalApprovalState) ? "None" : attached.InternalApprovalState;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Varchar2;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "seastate";
                        paramDoc.Value = string.IsNullOrEmpty(attached.ExternalApprovalState) ? "None" : attached.ExternalApprovalState;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Varchar2;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "sfile_name";
                        paramDoc.Value = attached.Name;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Blob;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "bfile_content";
                        paramDoc.Value = attached.Body;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Varchar2;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "snote";
                        paramDoc.Value = string.IsNullOrEmpty(attached.Note) ? string.Empty : attached.Note;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Varchar2;
                        paramDoc.Direction = ParameterDirection.Input;
                        paramDoc.ParameterName = "surl_api";
                        paramDoc.Value = attached.Link;
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        paramDoc = cmdEDMJRDoc.CreateParameter();
                        paramDoc.OracleDbType = OracleDbType.Int64;
                        paramDoc.Direction = ParameterDirection.Output;
                        paramDoc.ParameterName = "nedmjr_doc";
                        cmdEDMJRDoc.Parameters.Add(paramDoc);

                        cmdEDMJRDoc.ExecuteNonQuery();

                        long.TryParse(paramDoc.Value.ToString(), out long rnEDMJRDoc);
                    }
                }

                _drxPartyService.PostExchangeQueueItemAsync(authorizationDrxEQI, exchangeQueueItem.Id, nEDMJR);

            }
            transaction.Commit();
            return "Ok";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while performing the process of obtaining the ."); // <------------
            throw;
        }

    }

}
