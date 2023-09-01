﻿// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DirectumRx.Services;

/// <summary>
/// Defines methods for connecting parties.
/// </summary>
public interface IDrxPartyService
{
    /// <summary>
    /// Serialize the connection party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="ConnectPartyRequest"/>.</param>
    /// <returns>The serialized value.</returns>
    Task<DrxConnectCheckingRequest> FindConnectAsync(ConnectPartyRequest request);

    /// <summary>
    /// Serialize the company party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="BusinessUnitPartyRequest"/>.</param>
    /// <returns>The serialized value.</returns>
    Task<DrxBusinessUnitRequest> FindBusinessUnitAsync(BusinessUnitPartyRequest request);

    /// <summary>
    /// Serialize the employee party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="EmployeePartyRequest"/>.</param>
    /// <returns>The serialized value.</returns>
    Task<DrxEmployeeRequest> FindEmployeeAsync(EmployeePartyRequest request);

    /// <summary>
    /// Serialize the document type and kind party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="DocumentTypeKindPartyRequest"/>.</param>
    /// <returns>The serialized value.</returns>
    Task<DrxDocumentTypeKind> FindDocTypeKindAsync(DocTypeKindPartyRequest request);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="packages">The <see cref="PackagesLifeCycle"/>.</param>
    /// <returns>The serialized value.</returns>
    Task<PackagesLifeCycle> FindPackagesAsync(PostPackages packages);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="packages">The <see cref="PackagesLifeCycle"/>.</param>
    /// <returns>The serialized value.</returns>
    Task<PackagesLifeCycle> FindPackagesLifeCycleAsync(PostPackagesLifeCycle packages);

    /// <summary>
    /// Serialize the user token party content to a byte array as an asynchronous operation..
    /// </summary>
    /// <param name="request">The <see cref="UserTokenPartyRequest"/>.</param>
    /// <returns>The serialized value.</returns>
    Task<DrxUserTokenRequest> FindUserTokenAsync(Authorization authorization);

    /// <summary>
    /// Serialize the contract category party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="ContractCategoryPartyRequest"/>.</param>
    /// <returns>The serialized value.</returns>
    Task<DrxContractCategoriesRequest> FindContractCategoryAsync(DrxContractCategoriesPartyRequest request);

    /// <summary>
    /// Serialize the document register party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="DocumentRegisterPartyRequest"/>.</param>
    /// <returns>The serialized value.</returns>
    Task<DrxDocumentRegisterRequest> FindDocumentRegisterAsync(DrxDocumentRegisterPartyRequest request);

    /// <summary>
    /// Serialize the document...
    /// </summary>
    /// <param name="request">The <see cref="DrxExchangeQueueItems"/>.</param>
    /// <returns>The serialized value.</returns>
    Task<DrxExchangeQueueItems> FindExchangeQueueItemAsync(AuthorizationDrxEQI authorization);

    Task PostExchangeQueueItemAsync(AuthorizationDrxEQI authorization, int ExchangeQueueItemId, long PackegeParusRn);
}
