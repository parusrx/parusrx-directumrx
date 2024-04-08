// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Integration.Stores;

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
