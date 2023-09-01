// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
using Npgsql;

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

            var paramCrn = new DynamicParameters();
            paramCrn.Add("ncompany", authorizationDrxEQI.Company);
            paramCrn.Add("scode", "DRXEDMJournal");
            paramCrn.Add("ncrn", dbType: DbType.Int64, direction: ParameterDirection.Output);

            connection.Execute("parus.find_root_catalog", paramCrn, commandType: CommandType.StoredProcedure);

            if (long.TryParse(paramCrn.Get<Int64>("ncrn").ToString(), out var nCrn))
            {
                foreach (var exchangeQueueItem in exchangeQueueItems.ExchangeQueueItems)
                {
                    var paramAGN = new DynamicParameters();
                    paramAGN.Add("ncompany", authorizationDrxEQI.Company);

                    long.TryParse(exchangeQueueItem.CounterpartyTIN, out var tin);
                    long.TryParse(exchangeQueueItem.CounterpartyTRRC, out var trrc);

                    if (tin != 0)
                        paramAGN.Add("ntin", tin);
                    else
                        paramAGN.Add("ntin");

                    if (trrc != 0)
                        paramAGN.Add("ntrrc", trrc); 
                    else
                        paramAGN.Add("ntrrc");

                    paramAGN.Add("nagnlist", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    connection.Execute("parus.find_drxagnlist_tin", paramAGN, commandType: CommandType.StoredProcedure);

                    long.TryParse(paramAGN.Get<Int64>("nagnlist").ToString(), out var nAgent);

                    ///// Поиск регистрационного номера сотрудника
                    var paramEMP = new DynamicParameters();
                    paramEMP.Add("ncompany", authorizationDrxEQI.Company);
                    paramEMP.Add("ndrxconnect", authorizationDrxEQI.ConnectRn);
                    paramEMP.Add("nemployee_id", exchangeQueueItem.EmployeeId);
                    paramEMP.Add("nbusinessunit_id", authorizationDrxEQI.BusinessUnitId);
                    paramEMP.Add("nemployee_rn", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    connection.Execute("parus.find_drxemployee_id", paramEMP, commandType: CommandType.StoredProcedure);

                    long.TryParse(paramEMP.Get<Int64>("nemployee_rn").ToString(), out var nEmployeeRn);

                    ///Запрос статуса пакета документа по жизненому циклу основного документа
                    var paramLC = new DynamicParameters();
                    paramLC.Add("siastate", exchangeQueueItem.LeadingDocument.InternalApprovalState);
                    paramLC.Add("seastate", exchangeQueueItem.LeadingDocument.ExternalApprovalState);
                    paramLC.Add("slcstate",exchangeQueueItem.LeadingDocument.LifeCycleState);
                    if (tin != 0)
                        paramLC.Add("nagent", tin);
                    else
                        paramLC.Add("nagent");
                    paramLC.Add("nstatus", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    connection.Execute("parus.find_drxedmjr_life_cycle", paramLC, commandType: CommandType.StoredProcedure);

                    long.TryParse(paramLC.Get<Int64>("nstatus").ToString(), out var nStatus);

                    /// Добавление записи в Журнал взаимодействия
                    var paramEDMJR = new DynamicParameters();
                    paramEDMJR.Add("ncompany", authorizationDrxEQI.Company);
                    paramEDMJR.Add("ncrn", nCrn);
                    paramEDMJR.Add("njur_pers", authorizationDrxEQI.Jurpers);
                    paramEDMJR.Add("drec_date");
                    paramEDMJR.Add("ndocflow", 0);
                    paramEDMJR.Add("sdescription", exchangeQueueItem.Name);
                    paramEDMJR.Add("nstatus", nStatus == 0 ? 2 : nStatus);
                    paramEDMJR.Add("nagent", nAgent != 0 ? nAgent : null);
                    paramEDMJR.Add("snote", exchangeQueueItem.Note);
                    paramEDMJR.Add("sauthid");
                    paramEDMJR.Add("ndrxconnect", authorizationDrxEQI.ConnectRn);
                    paramEDMJR.Add("ndrxcompany", authorizationDrxEQI.BusinessUnitRn);
                    paramEDMJR.Add("ndrxemployee", nEmployeeRn != 0 ? nEmployeeRn : null);
                    paramEDMJR.Add("nrn", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    connection.Execute("parus.p_drxedmjr_base_insert", paramEDMJR, commandType: CommandType.StoredProcedure);

                    if (long.TryParse(paramEDMJR.Get<Int64>("nrn").ToString(), out var nEDMJR))
                    {
                        /// Добавление основного документа в спецификацию журнала взаимодействия с DirectuRX
                        CreateEDMJRDocument(connection, transaction, authorizationDrxEQI, nEDMJR, exchangeQueueItem.LeadingDocument, 1);

                        /// Добавление дополнительных документов в спецификацию журнала взаимодействия с DirectuRX
                        foreach (var attachment in exchangeQueueItem.Attachments)
                        {
                            CreateEDMJRDocument(connection, transaction, authorizationDrxEQI, nEDMJR, attachment, 0);
                        }
                    }

                    _drxPartyService.PostExchangeQueueItemAsync(authorizationDrxEQI, exchangeQueueItem.Id, nEDMJR);

                }
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

    /// <inheritdoc/>
    public long GetRnDocumentType(IDbConnection connection, IDbTransaction transaction, long drxConnectRn, int documentTypeId)
    {
        try
        {
            /// Получить регистрационную запись типа документа
            var paramDTYPE = new DynamicParameters();
            paramDTYPE.Add("nflag_smart", 0);
            paramDTYPE.Add("ndrxconnect", drxConnectRn);
            paramDTYPE.Add("nid", documentTypeId);
            paramDTYPE.Add("nrn", dbType: DbType.Int64, direction: ParameterDirection.Output);

            connection.Execute("parus.find_drxdoctype_id", paramDTYPE, commandType: CommandType.StoredProcedure);

            long.TryParse(paramDTYPE.Get<Int64>("nrn").ToString(), out long rnDocType);
            return rnDocType;
        }

        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while performing the process of obtaining the ."); // <------------
            return 0;
        }
    }

    /// <inheritdoc/>
    public long GetRnDocumentKind(IDbConnection connection, IDbTransaction transaction, long drxConnectRn, long drxDocTypeRn, int documentKindId)
    {
        try
        {
            /// Получить регистрационную запись вида документа
            var paramDKIND = new DynamicParameters();
            paramDKIND.Add("nflag_smart", 0);
            paramDKIND.Add("ndrxconnect", drxConnectRn);
            paramDKIND.Add("ndrxdoctype", drxDocTypeRn);
            paramDKIND.Add("nid", documentKindId);
            paramDKIND.Add("nrn", dbType: DbType.Int64, direction: ParameterDirection.Output);

            connection.Execute("parus.find_drxdockind_id", paramDKIND, commandType: CommandType.StoredProcedure);

            long.TryParse(paramDKIND.Get<Int64>("nrn").ToString(), out long rnDocKind);
            return rnDocKind;
        }

        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while performing the process of obtaining the ."); // <------------
            return 0;
        }
    }

    /// <inheritdoc/>
    public long GetRnDocumentCategory(IDbConnection connection, IDbTransaction transaction, long drxConnectRn, int documentCategoryId)
    {
        try
        {
            /// Получить регистрационную запись категории документа
            var paramDCTG = new DynamicParameters();
            paramDCTG.Add("nflag_smart", 0);
            paramDCTG.Add("ndrxconnect", drxConnectRn);
            paramDCTG.Add("nid", documentCategoryId);
            paramDCTG.Add("nrn", dbType: DbType.Int64, direction: ParameterDirection.Output);

            connection.Execute("parus.find_drxdocctg_id", paramDCTG, commandType: CommandType.StoredProcedure);

            long.TryParse(paramDCTG.Get<Int64>("nrn").ToString(), out long rnDocCtg);
            return rnDocCtg;
        }

        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while performing the process of obtaining the ."); // <------------
            return 0;
        }
    }

    /// <inheritdoc/>
    public long GetRnDocumentRegister(IDbConnection connection, IDbTransaction transaction, long drxConnectRn, int documentRegisterId)
    {
        try
        {
            /// Получить регистрационную запись журнала регистрации документа
            var param = new DynamicParameters();
            param.Add("nflag_smart", 0);
            param.Add("ndrxconnect", drxConnectRn);
            param.Add("nid", documentRegisterId);
            param.Add("nrn", dbType: DbType.Int64, direction: ParameterDirection.Output);

            connection.Execute("parus.find_drxdocreg_id", param, commandType: CommandType.StoredProcedure);

            long.TryParse(param.Get<Int64>("nrn").ToString(), out long rnDocReg);
            return rnDocReg;
        }

        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while performing the process of obtaining the ."); // <------------
            return 0;
        }
    }

    public long CreateEDMJRDocument(IDbConnection connection, IDbTransaction transaction, AuthorizationDrxEQI authorizationDrx, long rnEDMJR, ExchangeQueueItemDocument document, int mainDocument)
    {
        try
        {
            /// Получить регистрационную запись типа документа
            var rnDocType = GetRnDocumentType(connection, transaction, authorizationDrx.ConnectRn, document.DocumentTypeId);

            /// Получить регистрационную запись вида документа
            var rnDocKind = GetRnDocumentKind(connection, transaction, authorizationDrx.Company, rnDocType, document.DocumentKindId);

            /// Получить регистрационную запись категории документа
            long rnDocCtg = 0;
            if (document.DocumentGroupId.HasValue)
                rnDocCtg = GetRnDocumentCategory(connection, transaction, authorizationDrx.ConnectRn, document.DocumentGroupId.Value);

            /// Получить регистрационную запись журнала регистрации документа
            long rnDocReg = 0;
            if (document.DocumentGroupId.HasValue)
                rnDocReg = GetRnDocumentRegister(connection, transaction, authorizationDrx.ConnectRn, document.DocumentRegisterId.Value);

            /// Получить регистрационную запись типа документа
            var paramDOC = new DynamicParameters();
            paramDOC.Add("ncompany", authorizationDrx.Company);
            paramDOC.Add("nprn", rnEDMJR);
            paramDOC.Add("ndocnumb");
            paramDOC.Add("nid", document.Id);
            paramDOC.Add("sdescription", document.Name);
            paramDOC.Add("nmain", mainDocument);
            paramDOC.Add("ddate_change");
            paramDOC.Add("ndrxdoctype", rnDocType);
            paramDOC.Add("ndrxdockind", rnDocKind);
            paramDOC.Add("ndrxdocctg", rnDocCtg != 0 ? rnDocCtg : null);
            paramDOC.Add("ndrxdocreg", rnDocReg != 0 ? rnDocReg : null);
            paramDOC.Add("sstate", string.IsNullOrEmpty(document.LifeCycleState) ? "None" : document.LifeCycleState);
            paramDOC.Add("sintapprstate", string.IsNullOrEmpty(document.InternalApprovalState) ? "None" : document.InternalApprovalState);
            paramDOC.Add("sextapprstate", string.IsNullOrEmpty(document.ExternalApprovalState) ? "None" : document.ExternalApprovalState);
            paramDOC.Add("sfile_name", document.Name);
            paramDOC.Add("sfile_content", document.Body);
            paramDOC.Add("snote", document.Note);
            paramDOC.Add("surl_api", document.Link);
            paramDOC.Add("nrn", dbType: DbType.Int64, direction: ParameterDirection.Output);

            connection.Execute("parus.p_drxedmjrdoc_base_insert", paramDOC, commandType: CommandType.StoredProcedure);

            long.TryParse(paramDOC.Get<Int64>("nrn").ToString(), out long rnEDMJRDoc);
            return rnEDMJRDoc;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while performing the process of obtaining the ."); // <------------
            return 0;
        }
    }
}
