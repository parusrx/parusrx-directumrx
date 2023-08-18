// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRx.Services.DirectumRx.Api.Models;

namespace ParusRx.Services.DirectumRx.Api.Services;

public interface IDrxSheduledService
{
    /// <summary>
    /// Gets execute document state.
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="State"/>
    Task<string> GetExecuteStateAsync(PackagesLifeCycle packagesLifeCycle);

    /// <summary>
    /// Gets exchange queue items.
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="Documents"/>
    Task<string> GetExchangeQueueItemAsync(AuthorizationDrxEQI authorizationDrxEQI, DrxExchangeQueueItems exchangeQueueItems);

    /// <summary>
    /// Gets rn docyment type.
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="Documents"/>
    long GetRnDocumentType(IDbConnection connection, IDbTransaction transaction, long drxConnectRn, int documentTypeId);

    /// <summary>
    /// Gets rn docyment kind.
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="Documents"/>
    long GetRnDocumentKind(IDbConnection connection, IDbTransaction transaction, long drxConnectRn, long drxDocTypeRn, int documentKindId);

    /// <summary>
    /// Gets rn docyment category.
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="Documents"/>
    long GetRnDocumentCategory(IDbConnection connection, IDbTransaction transaction, long drxConnectRn, int documentCategoryId);

    /// <summary>
    /// Gets rn docyment register.
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="Documents"/>
    long GetRnDocumentRegister(IDbConnection connection, IDbTransaction transaction, long drxConnectRn, int documentCategoryId);

    /// <summary>
    /// Create document EDMJR.
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="Documents"/>
    long CreateEDMJRDocument(IDbConnection connection, IDbTransaction transaction, AuthorizationDrxEQI authorizationDrx, long rnEDMJR, ExchangeQueueItemDocument document, int mainDocument);
}
