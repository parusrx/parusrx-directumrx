// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DirectumRx.Integration.Handlers;

/// <summary>
/// An implementation of <see cref="IIntegrationEventHandler"/> for DirectumRX interaction.
/// </summary>

public class UserTokenHandler : IIntegrationEventHandler
{
    private readonly IDrxPartyEventService _service;
    private readonly ILogger<UserTokenHandler> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="UserTokenPartyHandler"/> class.
    /// </summary>
    /// <param name="service">The <see cref="IDrxPartyEventService"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public UserTokenHandler(IDrxPartyEventService service,
        ILogger<UserTokenHandler> logger)
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

            await _service.FindPartyUserTokenAsync(@event);
        }
    }
}
