// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Drawing;
using Dapper;
using Microsoft.Extensions.Logging;

namespace ParusRx.DirectumRx.Integration.Stores.Oracle;

/// <summary>
/// Default credentials store.
/// </summary>
/// <seealso cref="IDrxScheduledStore"/>
public class DrxOracleScheduledStore : IDrxScheduledStore
{
    private readonly IConnection _connection;
    private readonly ILogger<DrxOracleScheduledStore> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="DrxScheduledStore"/> class.
    /// </summary>
    /// <param name="connection">The connection on database.</param>
    /// <param name="logger">The logger to use.</param>
    public DrxOracleScheduledStore(IConnection connection, ILogger<DrxOracleScheduledStore> logger)
    {
        _connection = connection;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task<List<PostPackagesLifeCycle>> GetAllPackagesLifeCycleAsync()
    {
        try
        {
            using var connection = _connection.ConnectionFactory.CreateConnection();
            connection.Open();
            List<PostPackagesLifeCycle> listPackagesLifeCycle = new List<PostPackagesLifeCycle>();
            PostPackagesLifeCycle packagesLifeCycle = new PostPackagesLifeCycle();
            var connects = await connection.QueryAsync<Authorization>("select c.url_api as Host, c.sysuser as Username, c.syspwd as Password, null as Token, c.rn as Rn from parus.drxconnect c where c.state = 1");

            if (connects.Any())
            {
                foreach (var connect in connects)
                {
                    packagesLifeCycle = new PostPackagesLifeCycle();
                    var packages = await connection.QueryAsync<PackageLifeCycle>("select distinct(p.rn) as Rn, p.status as Status, null as Error from parus.drxedmjr p left join parus.drxedmjrdoc d on p.rn = d.prn where p.drxconnect = " + connect.Rn + " and (p.status not in (0, 1, 5, 7) or (p.status = 6 and d.state != 'Delete'))");

                    if (packages.Any())
                    {
                        packagesLifeCycle.Authorization = connect;
                        foreach (var package in packages)
                        {
                            var documents = await connection.QueryAsync<DocumentLifeCycle>("select Id, Rn from parus.drxedmjrdoc where prn = " + package.Rn);
                            foreach (var document in documents)
                            {
                                document.Status = package.Status;
                            }
                            package.DocumentsLifeCycle = documents.ToList();
                        }
                        packagesLifeCycle.PackagesLifeCycleDto.PackageLifeCycle = packages.ToList();
                        listPackagesLifeCycle.Add(packagesLifeCycle);
                    }
                }
            }
            return listPackagesLifeCycle;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while obtaining credentials.");
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<List<AuthorizationDrxEQI>> GetExchangeQueueItemAsync()
    {
        try
        {
            using var connection = _connection.ConnectionFactory.CreateConnection();
            connection.Open();
            var connects = await connection.QueryAsync<AuthorizationDrxEQI>("select d.rn as ConnectRn, d.url_api as Host, d.sysuser as Username, d.syspwd as Password, c.rn as BusinessUnitRN, c.company as Company, c.id as BusinessUnitId, c.jurpers as Jurpers from parus.drxconnect d left join parus.drxcompany c on d.rn = c.prn where c.jurpers is not null and c.status = 'Active'");

            if (connects.Any())
            {
                return connects.ToList();
            }
            else
                return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while obtaining credentials.");
            throw;
        }
    }
}
