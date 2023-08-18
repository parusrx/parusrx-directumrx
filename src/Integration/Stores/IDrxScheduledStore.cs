// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Services.DirectumRx.Api.Integration.Stores;

/// <summary>
/// Provides methods allowing to retrieve credentials stored in a database.
/// </summary>
public interface IDrxScheduledStore
{
    /// <summary>
    /// Gets all packages documents life cycle state.
    /// </summary>
    /// <returns>The credentials.</returns>
    /// <seealso cref="PostPackagesLifeCycle"/>
    Task<List<PostPackagesLifeCycle>> GetAllPackagesLifeCycleAsync();

    /// <summary>
    /// Gets all packages documents life cycle state.
    /// </summary>
    /// <returns>The credentials.</returns>
    /// <seealso cref="AuthorizationDrxEQI"/>
    Task<List<AuthorizationDrxEQI>> GetExchangeQueueItemAsync();
}
