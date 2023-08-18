﻿// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Services.DirectumRx.Api.Integration.Handlers;

/// <summary>
/// An implementation of<see cref="IIntegrationEventHandler"/> for DirectumRX interaction.
/// </summary>
public class PackagesLifeCycleHandler : IIntegrationEventHandler
{
    private readonly IDrxPartyEventService _service;
    private readonly ILogger<PackagesLifeCycleHandler> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="IDrxPartyEventService"/> class.
    /// </summary>
    /// <param name="service">The <see cref="IDrxPartyEventService"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public PackagesLifeCycleHandler(IDrxPartyEventService service,
        ILogger<PackagesLifeCycleHandler> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task HandleAsync(MqIntegrationEvent @event)
    {
        using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
        {
            _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

            await _service.FindPartyPackagesLifeCycleStateAsync(@event);
        }
    }
}
