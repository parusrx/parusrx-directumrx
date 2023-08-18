// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Net;

namespace ParusRx.Services.DirectumRx.Api.Controllers;

/// <summary>
/// Represents the Scheduled controller.
/// </summary>
public class DrxScheduledController : Controller
{
    private readonly IDrxSheduledService _drxSheduledService;
    private readonly IDrxScheduledStore _docStateStore;
    private readonly IDrxPartyService _drxPartyService;

    /// <summary>
    /// Initializes a new instance of <see cref="DrxScheduledController"/>.
    /// </summary>
    /// <param name="drxStateDocuments">The <see cref="IDrxStateDocuments"/>.</param>
    public DrxScheduledController(IDrxSheduledService drxSheduledService, IDrxScheduledStore drxScheduledStore, IDrxPartyService drxPartyService)
    {
        _drxSheduledService = drxSheduledService;
        _docStateStore = drxScheduledStore;
        _drxPartyService = drxPartyService;
    }

    /// <summary>
    /// Retrieves a message.
    /// </summary>
    /// <remarks>
    ///     POST /scheduled
    /// </remarks>
    /// <responce code="200">Successful completion.</responce>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Route("scheduled")]
    public async Task<IActionResult> DocumentStateAsync()
    {
        var allPackages = await _docStateStore.GetAllPackagesLifeCycleAsync();
        foreach (var packagesLifeCycle in allPackages)
        {
            if (packagesLifeCycle.PackagesLifeCycleDto.PackageLifeCycle.Any())
            {
                var packages = await _drxPartyService.FindPackagesLifeCycleAsync(packagesLifeCycle);
                await _drxSheduledService.GetExecuteStateAsync(packages);
            }
            else
            {
                return NotFound();
            }
        }
        return Ok();
    }

    /// <summary>
    /// Retrieves a message.
    /// </summary>
    /// <remarks>
    ///     POST /scheduled
    /// </remarks>
    /// <responce code="200">Successful completion.</responce>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Route("exchange-queue")]
    public async Task<IActionResult> ExchangeQueueItemsAsync()
    {
        var authorizationDrxEQIs = await _docStateStore.GetExchangeQueueItemAsync();
        foreach (var authorizationDrxEQI in authorizationDrxEQIs)
        {
            if (authorizationDrxEQI.BusinessUnitId != null)
            {
                var exchangeQueueItems = await _drxPartyService.FindExchangeQueueItemAsync(authorizationDrxEQI);
                if(exchangeQueueItems != null)
                    await _drxSheduledService.GetExchangeQueueItemAsync(authorizationDrxEQI, exchangeQueueItems);
            }
            else
            {
                return NotFound();
            }
        }
        return Ok();
    }
}
