﻿// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Integration.Handlers;

/// <summary>
/// An implementation of <see cref="IIntegrationEventHandler"/> for DirectumRX interaction.
/// </summary>

public class EmployeeHandler : IIntegrationEventHandler
{
    private readonly IDrxPartyEventService _service;
    private readonly ILogger<EmployeeHandler> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="EmployeePartyHandler"/> class.
    /// </summary>
    /// <param name="service">The <see cref="IDrxPartyEventService"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public EmployeeHandler(IDrxPartyEventService service,
        ILogger<EmployeeHandler> logger)
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

            await _service.FindPartyEmployeeAsync(@event);
        }
    }
}
