// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Controllers;

/// <summary>
/// This controller implements integration event logic for DirectumRX interaction.
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
public class DrxEventController : ControllerBase
{
    private const string DAPR_PUBSUB_NAME = "pubsub";
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of <see cref="DrxEventController"/> class.
    /// </summary>
    /// <param name="serviceProvider">The <see cref="IServiceProvider"/> used to resolve services.</param>
    public DrxEventController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Retrieving a suggestions on a party.
    /// </summary>
    /// <param name="event">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>A <see cref="Task"/> that completes when processing has completed.</returns>
    [HttpPost("party")]
    [Topic(DAPR_PUBSUB_NAME, "DrxConnectCheckingStatusEvent")]
    public async Task GetParties(MqIntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<ConnectHandler>();
        await handler.HandleAsync(@event);
    }

    /// <summary>
    /// Get a company from DirectumRX.
    /// </summary>
    /// <param name="event">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>A <see cref="Task"/> that completes when processing has completed.</returns>
    [HttpPost("businessunit")]
    [Topic(DAPR_PUBSUB_NAME, "DrxBusinessUnitPartyEvent")]
    public async Task GetBusinessUnit(MqIntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<BusinessUnitHandler>();
        await handler.HandleAsync(@event);
    }

    /// <summary>
    /// Get a person from DirectumRX.
    /// </summary>
    /// <param name="event">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>A <see cref="Task"/> that completes when processing has completed.</returns>
    [HttpPost("person")]
    [Topic(DAPR_PUBSUB_NAME, "DrxPersonPartyEvent")]
    public async Task GetPerson(MqIntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<PersonHandler>();
        await handler.HandleAsync(@event);
    }

    /// <summary>
    /// Get a department from DirectumRX.
    /// </summary>
    /// <param name="event">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>A <see cref="Task"/> that completes when processing has completed.</returns>
    [HttpPost("department")]
    [Topic(DAPR_PUBSUB_NAME, "DrxDepartmentPartyEvent")]
    public async Task GetDepartment(MqIntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<DepartmentHandler>();
        await handler.HandleAsync(@event);
    }

    /// <summary>
    /// Get a job title from DirectumRX.
    /// </summary>
    /// <param name="event">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>A <see cref="Task"/> that completes when processing has completed.</returns>
    [HttpPost("jobtitle")]
    [Topic(DAPR_PUBSUB_NAME, "DrxJobTitlePartyEvent")]
    public async Task GetJobTitle(MqIntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<JobTitleHandler>();
        await handler.HandleAsync(@event);
    }

    /// <summary>
    /// Get a employee from DirectumRX.
    /// </summary>
    /// <param name="event">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>A <see cref="Task"/> that completes when processing has completed.</returns>
    [HttpPost("employee")]
    [Topic(DAPR_PUBSUB_NAME, "DrxEmployeePartyEvent")]
    public async Task GetEmployee(MqIntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<EmployeeHandler>();
        await handler.HandleAsync(@event);
    }

    /// <summary>
    /// Get a docyment type and kind from DirectumRX.
    /// </summary>
    /// <param name="event">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>A <see cref="Task"/> that completes when processing has completed.</returns>
    [HttpPost("doctypekind")]
    [Topic(DAPR_PUBSUB_NAME, "DrxDocumentTypeKindPartyEvent")]
    public async Task GetDocTypeKind(MqIntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<DocumentTypeKindHandler>();
        await handler.HandleAsync(@event);
    }

    /// <summary>
    /// Post a packages invoice from DirectumRX.
    /// </summary>
    /// <param name="event">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>A <see cref="Task"/> that completes when processing has completed.</returns>
    [HttpPost("packages")]
    [Topic(DAPR_PUBSUB_NAME, "DrxPackagesPartyEvent")]
    public async Task PostPackages(MqIntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<PackagesHandler>();
        await handler.HandleAsync(@event);
    }

    /// <summary>
    /// Post a packages life cycle state from DirectumRX.
    /// </summary>
    /// <param name="event">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>A <see cref="Task"/> that completes when processing has completed.</returns>
    [HttpPost("packageslifecycletate")]
    [Topic(DAPR_PUBSUB_NAME, "DrxPackagesLifeCycleStatePartyEvent")]
    public async Task GetPackagesLifeCycleState(MqIntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<PackagesLifeCycleStateHandler>();
        await handler.HandleAsync(@event);
    }

    /// <summary>
    /// Get a user token for authentication in DirectumRX
    /// </summary>
    /// <param name="event">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>A <see cref="Task"/> that completes when processing has completed.</returns>
    [HttpPost("usertoken")]
    [Topic(DAPR_PUBSUB_NAME, "DrxUserTokenPartyEvent")]
    public async Task GetUserTokenState(MqIntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<UserTokenHandler>();
        await handler.HandleAsync(@event);
    }

    /// <summary>
    /// Get a contract category in DirectumRX.
    /// </summary>
    /// <param name="event">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>A <see cref="Task"/> that completes when processing has completed.</returns>
    [HttpPost("contractcategory")]
    [Topic(DAPR_PUBSUB_NAME, "DrxContractCategoryPartyEvent")]
    public async Task GetContractCategory(MqIntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<ContractCategoryHandler>();
        await handler.HandleAsync(@event);
    }

    /// <summary>
    /// Get a document registers in DirectumRX.
    /// </summary>
    /// <param name="event">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>A <see cref="Task"/> that completes when processing has completed.</returns>
    [HttpPost("documentregister")]
    [Topic(DAPR_PUBSUB_NAME, "DrxDocumentRegisterPartyEvent")]
    public async Task GetDocumentRegister(MqIntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<DocumentRegisterHandler>();
        await handler.HandleAsync(@event);
    }
}
