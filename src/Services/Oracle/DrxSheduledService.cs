// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.ComponentModel.Design;
using System.Xml;
using Microsoft.Extensions.Logging;

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

            var cmd = new OracleCommand
            {
                Connection = (OracleConnection)connection,
                CommandType = CommandType.StoredProcedure,
                Transaction = (OracleTransaction)transaction,
                CommandText = "parus.find_root_catalog"
            };

            var paramCrn = cmd.CreateParameter();
            paramCrn.OracleDbType = OracleDbType.Int64;
            paramCrn.Direction = ParameterDirection.Input;
            paramCrn.ParameterName = "ncompany";
            paramCrn.Value = authorizationDrxEQI.Company;
            cmd.Parameters.Add(paramCrn);

            paramCrn = cmd.CreateParameter();
            paramCrn.OracleDbType = OracleDbType.Varchar2;
            paramCrn.Direction = ParameterDirection.Input;
            paramCrn.ParameterName = "scode";
            paramCrn.Value = "DRXEDMJournal";
            cmd.Parameters.Add(paramCrn);

            paramCrn = cmd.CreateParameter();
            paramCrn.OracleDbType = OracleDbType.Int64;
            paramCrn.Direction = ParameterDirection.Output;
            paramCrn.ParameterName = "ncrn";
            cmd.Parameters.Add(paramCrn);

            cmd.ExecuteNonQuery();

            if (long.TryParse(paramCrn.Value.ToString(), out var nCrn))
            {
                foreach (var exchangeQueueItem in exchangeQueueItems.ExchangeQueueItems)
                {
                    /// Поиск контрагента
                    var cmdAGENT = new OracleCommand
                    {
                        Connection = (OracleConnection)connection,
                        CommandType = CommandType.StoredProcedure,
                        Transaction = (OracleTransaction)transaction,
                        CommandText = "parus.find_drxagnlist_tin"
                    };

                    var paramAGN = cmdAGENT.CreateParameter();
                    paramAGN.OracleDbType = OracleDbType.Int64;
                    paramAGN.Direction = ParameterDirection.Input;
                    paramAGN.ParameterName = "ncompany";
                    paramAGN.Value = authorizationDrxEQI.Company;
                    cmdAGENT.Parameters.Add(paramAGN);

                    long.TryParse(exchangeQueueItem.CounterpartyTIN, out var tin);
                    long.TryParse(exchangeQueueItem.CounterpartyTRRC, out var trrc);

                    paramAGN = cmdAGENT.CreateParameter();
                    paramAGN.OracleDbType = OracleDbType.Int64;
                    paramAGN.Direction = ParameterDirection.Input;
                    paramAGN.ParameterName = "ntin";
                    if (tin != 0)
                        paramAGN.Value = tin;
                    cmdAGENT.Parameters.Add(paramAGN);

                    paramAGN = cmdAGENT.CreateParameter();
                    paramAGN.OracleDbType = OracleDbType.Int64;
                    paramAGN.Direction = ParameterDirection.Input;
                    paramAGN.ParameterName = "ntrrc";
                    if (trrc != 0)
                        paramAGN.Value = trrc;
                    cmdAGENT.Parameters.Add(paramAGN);

                    paramAGN = cmdAGENT.CreateParameter();
                    paramAGN.OracleDbType = OracleDbType.Int64;
                    paramAGN.Direction = ParameterDirection.Output;
                    paramAGN.ParameterName = "nagnlist";
                    cmdAGENT.Parameters.Add(paramAGN);

                    cmdAGENT.ExecuteNonQuery();

                    long.TryParse(paramAGN.Value.ToString(), out var nAgent);

                    /// Поиск регистрационного номера сотрудника
                    var cmdEMP = new OracleCommand
                    {
                        Connection = (OracleConnection)connection,
                        CommandType = CommandType.StoredProcedure,
                        Transaction = (OracleTransaction)transaction,
                        CommandText = "parus.find_drxemployee_id"
                    };

                    var paramEMP = cmdEMP.CreateParameter();
                    paramEMP.OracleDbType = OracleDbType.Int64;
                    paramEMP.Direction = ParameterDirection.Input;
                    paramEMP.ParameterName = "ncompany";
                    paramEMP.Value = authorizationDrxEQI.Company;
                    cmdEMP.Parameters.Add(paramEMP);

                    paramEMP = cmdEMP.CreateParameter();
                    paramEMP.OracleDbType = OracleDbType.Int64;
                    paramEMP.Direction = ParameterDirection.Input;
                    paramEMP.ParameterName = "ndrxconnect";
                    paramEMP.Value = authorizationDrxEQI.ConnectRn;
                    cmdEMP.Parameters.Add(paramEMP);

                    paramEMP = cmdEMP.CreateParameter();
                    paramEMP.OracleDbType = OracleDbType.Int64;
                    paramEMP.Direction = ParameterDirection.Input;
                    paramEMP.ParameterName = "nemployee_id";
                    paramEMP.Value = exchangeQueueItem.EmployeeId;
                    cmdEMP.Parameters.Add(paramEMP);

                    paramEMP = cmdEMP.CreateParameter();
                    paramEMP.OracleDbType = OracleDbType.Int64;
                    paramEMP.Direction = ParameterDirection.Input;
                    paramEMP.ParameterName = "nbusinessunit_id";
                    paramEMP.Value = authorizationDrxEQI.BusinessUnitId;
                    cmdEMP.Parameters.Add(paramEMP);

                    paramEMP = cmdEMP.CreateParameter();
                    paramEMP.OracleDbType = OracleDbType.Int64;
                    paramEMP.Direction = ParameterDirection.Output;
                    paramEMP.ParameterName = "nemployee_rn";
                    cmdEMP.Parameters.Add(paramEMP);

                    cmdEMP.ExecuteNonQuery();

                    long.TryParse(paramEMP.Value.ToString(), out var nEmployeeRn);

                    ///Запрос статуса пакета документа по жизненому циклу основного документа
                    var cmdLS = new OracleCommand
                    {
                        Connection = (OracleConnection)connection,
                        CommandType = CommandType.StoredProcedure,
                        Transaction = (OracleTransaction)transaction,
                        CommandText = "parus.find_drxedmjr_life_cycle"
                    };

                    var paramLC = cmdLS.CreateParameter();
                    paramLC.OracleDbType = OracleDbType.Varchar2;
                    paramLC.Direction = ParameterDirection.Input;
                    paramLC.ParameterName = "siastate";
                    paramLC.Value = exchangeQueueItem.LeadingDocument.InternalApprovalState;
                    cmdLS.Parameters.Add(paramLC);

                    paramLC = cmdLS.CreateParameter();
                    paramLC.OracleDbType = OracleDbType.Varchar2;
                    paramLC.Direction = ParameterDirection.Input;
                    paramLC.ParameterName = "seastate";
                    paramLC.Value = exchangeQueueItem.LeadingDocument.ExternalApprovalState;
                    cmdLS.Parameters.Add(paramLC);

                    paramLC = cmdLS.CreateParameter();
                    paramLC.OracleDbType = OracleDbType.Varchar2;
                    paramLC.Direction = ParameterDirection.Input;
                    paramLC.ParameterName = "slcstate";
                    paramLC.Value = exchangeQueueItem.LeadingDocument.LifeCycleState;
                    cmdLS.Parameters.Add(paramLC);

                    paramLC = cmdLS.CreateParameter();
                    paramLC.OracleDbType = OracleDbType.Int64;
                    paramLC.Direction = ParameterDirection.Input;
                    paramLC.ParameterName = "nagent";
                    if (tin != 0)
                        paramLC.Value = tin;
                    cmdLS.Parameters.Add(paramLC);

                    paramLC = cmdLS.CreateParameter();
                    paramLC.OracleDbType = OracleDbType.Int64;
                    paramLC.Direction = ParameterDirection.Output;
                    paramLC.ParameterName = "nstatus";
                    cmdLS.Parameters.Add(paramLC);

                    cmdLS.ExecuteNonQuery();

                    long.TryParse(paramLC.Value.ToString(), out var nStatus);

                    /// Добавление записи в Журнал взаимодействия
                    var cmdEDMJR = new OracleCommand
                    {
                        Connection = (OracleConnection)connection,
                        CommandType = CommandType.StoredProcedure,
                        Transaction = (OracleTransaction)transaction,
                        CommandText = "parus.p_drxedmjr_base_insert"
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
                    paramEDMJR.ParameterName = "ncrn";
                    paramEDMJR.Value = nCrn;
                    cmdEDMJR.Parameters.Add(paramEDMJR);

                    paramEDMJR = cmdEDMJR.CreateParameter();
                    paramEDMJR.OracleDbType = OracleDbType.Int64;
                    paramEDMJR.Direction = ParameterDirection.Input;
                    paramEDMJR.ParameterName = "njur_pers";
                    paramEDMJR.Value = authorizationDrxEQI.Jurpers;
                    cmdEDMJR.Parameters.Add(paramEDMJR);

                    paramEDMJR = cmdEDMJR.CreateParameter();
                    paramEDMJR.OracleDbType = OracleDbType.Date;
                    paramEDMJR.Direction = ParameterDirection.Input;
                    paramEDMJR.ParameterName = "drec_date";
                    ///paramEDMJR.Value = DateTime.UtcNow;
                    cmdEDMJR.Parameters.Add(paramEDMJR);

                    paramEDMJR = cmdEDMJR.CreateParameter();
                    paramEDMJR.OracleDbType = OracleDbType.Int64;
                    paramEDMJR.Direction = ParameterDirection.Input;
                    paramEDMJR.ParameterName = "ndocflow";
                    paramEDMJR.Value = 0;
                    cmdEDMJR.Parameters.Add(paramEDMJR);

                    paramEDMJR = cmdEDMJR.CreateParameter();
                    paramEDMJR.OracleDbType = OracleDbType.Varchar2;
                    paramEDMJR.Direction = ParameterDirection.Input;
                    paramEDMJR.ParameterName = "sdescription";
                    paramEDMJR.Value = exchangeQueueItem.Name;
                    cmdEDMJR.Parameters.Add(paramEDMJR);

                    paramEDMJR = cmdEDMJR.CreateParameter();
                    paramEDMJR.OracleDbType = OracleDbType.Int64;
                    paramEDMJR.Direction = ParameterDirection.Input;
                    paramEDMJR.ParameterName = "nstatus";
                    paramEDMJR.Value = nStatus == 0 ? 2 : nStatus;
                    cmdEDMJR.Parameters.Add(paramEDMJR);

                    paramEDMJR = cmdEDMJR.CreateParameter();
                    paramEDMJR.OracleDbType = OracleDbType.Int64;
                    paramEDMJR.Direction = ParameterDirection.Input;
                    paramEDMJR.ParameterName = "nagent";
                    if (nAgent != 0)
                        paramEDMJR.Value = nAgent;
                    cmdEDMJR.Parameters.Add(paramEDMJR);

                    paramEDMJR = cmdEDMJR.CreateParameter();
                    paramEDMJR.OracleDbType = OracleDbType.Varchar2;
                    paramEDMJR.Direction = ParameterDirection.Input;
                    paramEDMJR.ParameterName = "snote";
                    paramEDMJR.Value = exchangeQueueItem.Note;
                    cmdEDMJR.Parameters.Add(paramEDMJR);

                    paramEDMJR = cmdEDMJR.CreateParameter();
                    paramEDMJR.OracleDbType = OracleDbType.Varchar2;
                    paramEDMJR.Direction = ParameterDirection.Input;
                    paramEDMJR.ParameterName = "sauthid";
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
                    paramEDMJR.OracleDbType = OracleDbType.Int64;
                    paramEDMJR.Direction = ParameterDirection.Input;
                    paramEDMJR.ParameterName = "ndrxemployee";
                    if (nEmployeeRn != 0)
                        paramEDMJR.Value = nEmployeeRn;
                    cmdEDMJR.Parameters.Add(paramEDMJR);

                    paramEDMJR = cmdEDMJR.CreateParameter();
                    paramEDMJR.OracleDbType = OracleDbType.Int64;
                    paramEDMJR.Direction = ParameterDirection.Output;
                    paramEDMJR.ParameterName = "nrn";
                    cmdEDMJR.Parameters.Add(paramEDMJR);

                    cmdEDMJR.ExecuteNonQuery();

                    if (long.TryParse(paramEDMJR.Value.ToString(), out var nEDMJR))
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
            var cmdDTYPE = new OracleCommand
            {
                Connection = (OracleConnection)connection,
                CommandType = CommandType.StoredProcedure,
                Transaction = (OracleTransaction)transaction,
                CommandText = "parus.find_drxdoctype_id"
            };

            var paramDTYPE = cmdDTYPE.CreateParameter();
            paramDTYPE.OracleDbType = OracleDbType.Int64;
            paramDTYPE.Direction = ParameterDirection.Input;
            paramDTYPE.ParameterName = "nflag_smart";
            paramDTYPE.Value = 0;
            cmdDTYPE.Parameters.Add(paramDTYPE);

            paramDTYPE = cmdDTYPE.CreateParameter();
            paramDTYPE.OracleDbType = OracleDbType.Int64;
            paramDTYPE.Direction = ParameterDirection.Input;
            paramDTYPE.ParameterName = "ndrxconnect";
            paramDTYPE.Value = drxConnectRn;
            cmdDTYPE.Parameters.Add(paramDTYPE);

            paramDTYPE = cmdDTYPE.CreateParameter();
            paramDTYPE.OracleDbType = OracleDbType.Int64;
            paramDTYPE.Direction = ParameterDirection.Input;
            paramDTYPE.ParameterName = "nid";
            paramDTYPE.Value = documentTypeId;
            cmdDTYPE.Parameters.Add(paramDTYPE);

            paramDTYPE = cmdDTYPE.CreateParameter();
            paramDTYPE.OracleDbType = OracleDbType.Int64;
            paramDTYPE.Direction = ParameterDirection.Output;
            paramDTYPE.ParameterName = "nrn";
            cmdDTYPE.Parameters.Add(paramDTYPE);

            cmdDTYPE.ExecuteNonQuery();

            long.TryParse(paramDTYPE.Value.ToString(), out long rnDocType);
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
            var cmdDKIND = new OracleCommand
            {
                Connection = (OracleConnection)connection,
                CommandType = CommandType.StoredProcedure,
                Transaction = (OracleTransaction)transaction,
                CommandText = "parus.find_drxdockind_id"
            };

            var paramDKIND = cmdDKIND.CreateParameter();
            paramDKIND.OracleDbType = OracleDbType.Int64;
            paramDKIND.Direction = ParameterDirection.Input;
            paramDKIND.ParameterName = "nflag_smart";
            paramDKIND.Value = 0;
            cmdDKIND.Parameters.Add(paramDKIND);

            paramDKIND = cmdDKIND.CreateParameter();
            paramDKIND.OracleDbType = OracleDbType.Int64;
            paramDKIND.Direction = ParameterDirection.Input;
            paramDKIND.ParameterName = "ndrxconnect";
            paramDKIND.Value = drxConnectRn;
            cmdDKIND.Parameters.Add(paramDKIND);

            paramDKIND = cmdDKIND.CreateParameter();
            paramDKIND.OracleDbType = OracleDbType.Int64;
            paramDKIND.Direction = ParameterDirection.Input;
            paramDKIND.ParameterName = "ndrxdoctype";
            paramDKIND.Value = drxDocTypeRn;
            cmdDKIND.Parameters.Add(paramDKIND);

            paramDKIND = cmdDKIND.CreateParameter();
            paramDKIND.OracleDbType = OracleDbType.Int64;
            paramDKIND.Direction = ParameterDirection.Input;
            paramDKIND.ParameterName = "nid";
            paramDKIND.Value = documentKindId;
            cmdDKIND.Parameters.Add(paramDKIND);

            paramDKIND = cmdDKIND.CreateParameter();
            paramDKIND.OracleDbType = OracleDbType.Int64;
            paramDKIND.Direction = ParameterDirection.Output;
            paramDKIND.ParameterName = "nrn";
            cmdDKIND.Parameters.Add(paramDKIND);

            cmdDKIND.ExecuteNonQuery();

            long.TryParse(paramDKIND.Value.ToString(), out long rnDocKind);
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
            var cmdDCTG = new OracleCommand
            {
                Connection = (OracleConnection)connection,
                CommandType = CommandType.StoredProcedure,
                Transaction = (OracleTransaction)transaction,
                CommandText = "parus.find_drxdocctg_id"
            };

            var paramDCTG = cmdDCTG.CreateParameter();
            paramDCTG.OracleDbType = OracleDbType.Int64;
            paramDCTG.Direction = ParameterDirection.Input;
            paramDCTG.ParameterName = "nflag_smart";
            paramDCTG.Value = 0;
            cmdDCTG.Parameters.Add(paramDCTG);

            paramDCTG = cmdDCTG.CreateParameter();
            paramDCTG.OracleDbType = OracleDbType.Int64;
            paramDCTG.Direction = ParameterDirection.Input;
            paramDCTG.ParameterName = "ndrxconnect";
            paramDCTG.Value = drxConnectRn;
            cmdDCTG.Parameters.Add(paramDCTG);

            paramDCTG = cmdDCTG.CreateParameter();
            paramDCTG.OracleDbType = OracleDbType.Int64;
            paramDCTG.Direction = ParameterDirection.Input;
            paramDCTG.ParameterName = "nid";
            paramDCTG.Value = documentCategoryId;
            cmdDCTG.Parameters.Add(paramDCTG);

            paramDCTG = cmdDCTG.CreateParameter();
            paramDCTG.OracleDbType = OracleDbType.Int64;
            paramDCTG.Direction = ParameterDirection.Output;
            paramDCTG.ParameterName = "nrn";
            cmdDCTG.Parameters.Add(paramDCTG);

            cmdDCTG.ExecuteNonQuery();

            long.TryParse(paramDCTG.Value.ToString(), out long rnDocCtg);
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
            var cmd = new OracleCommand
            {
                Connection = (OracleConnection)connection,
                CommandType = CommandType.StoredProcedure,
                Transaction = (OracleTransaction)transaction,
                CommandText = "parus.find_drxdocreg_id"
            };

            var param = cmd.CreateParameter();
            param.OracleDbType = OracleDbType.Int64;
            param.Direction = ParameterDirection.Input;
            param.ParameterName = "nflag_smart";
            param.Value = 0;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.OracleDbType = OracleDbType.Int64;
            param.Direction = ParameterDirection.Input;
            param.ParameterName = "ndrxconnect";
            param.Value = drxConnectRn;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.OracleDbType = OracleDbType.Int64;
            param.Direction = ParameterDirection.Input;
            param.ParameterName = "nid";
            param.Value = documentRegisterId;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.OracleDbType = OracleDbType.Int64;
            param.Direction = ParameterDirection.Output;
            param.ParameterName = "nrn";
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            long.TryParse(param.Value.ToString(), out long rnDocReg);
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
            var cmdDOC = new OracleCommand
            {
                Connection = (OracleConnection)connection,
                CommandType = CommandType.StoredProcedure,
                Transaction = (OracleTransaction)transaction,
                CommandText = "parus.p_drxedmjrdoc_base_insert"
            };

            var paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Int64;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "ncompany";
            paramDOC.Value = authorizationDrx.Company;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Int64;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "nprn";
            paramDOC.Value = rnEDMJR;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Int64;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "ndocnumb";
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Int64;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "nid";
            paramDOC.Value = document.Id;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Varchar2;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "sdescription";
            paramDOC.Value = document.Name;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Int64;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "nmain";
            paramDOC.Value = mainDocument;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Date;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "ddate_change";
            ///paramDOC.Value = DateTime.Today;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Int64;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "ndrxdoctype";
            paramDOC.Value = rnDocType;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Int64;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "ndrxdockind";
            paramDOC.Value = rnDocKind;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Int64;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "ndrxdocctg";
            if (rnDocCtg != 0)
                paramDOC.Value = rnDocCtg;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Int64;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "ndrxdocreg";
            if (rnDocReg != 0)
                paramDOC.Value = rnDocReg;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Varchar2;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "sstate";
            paramDOC.Value = string.IsNullOrEmpty(document.LifeCycleState) ? "None" : document.LifeCycleState;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Varchar2;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "sintapprstate";
            paramDOC.Value = string.IsNullOrEmpty(document.InternalApprovalState) ? "None" : document.InternalApprovalState;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Varchar2;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "sextapprstate";
            paramDOC.Value = string.IsNullOrEmpty(document.ExternalApprovalState) ? "None" : document.ExternalApprovalState;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Varchar2;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "sfile_name";
            paramDOC.Value = document.Name;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Blob;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "sfile_content";
            paramDOC.Value = document.Body;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Varchar2;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "snote";
            paramDOC.Value = document.Note;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Varchar2;
            paramDOC.Direction = ParameterDirection.Input;
            paramDOC.ParameterName = "surl_api";
            paramDOC.Value = document.Link;
            cmdDOC.Parameters.Add(paramDOC);

            paramDOC = cmdDOC.CreateParameter();
            paramDOC.OracleDbType = OracleDbType.Int64;
            paramDOC.Direction = ParameterDirection.Output;
            paramDOC.ParameterName = "nrn";
            cmdDOC.Parameters.Add(paramDOC);

            cmdDOC.ExecuteNonQuery();

            long.TryParse(paramDOC.Value.ToString(), out long rnEDMJRDoc);
            return rnEDMJRDoc;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while performing the process of obtaining the ."); // <------------
            return 0;
        }
    }
}
