// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using Microsoft.Extensions.Logging;

namespace ParusRx.DirectumRx.Integration;

/// <summary>
/// An implementation of <see cref="IDrxPartyEventService"/> for integration events with DirectumRX suggestions.
/// </summary>
/// 
public class DrxPartyEventService : IDrxPartyEventService
{
    private readonly IParusRxStore _store;
    private readonly IDrxPartyService _service;
    private readonly ILogger<DrxPartyEventService> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="DrxPartyEventService"/> class.
    /// </summary>
    /// <param name="store">The <see cref="IParusRxStore"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public DrxPartyEventService(IParusRxStore store,
        IDrxPartyService service,
        ILogger<DrxPartyEventService> logger)
    {
        _store = store;
        _service = service;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task FindPartyConnectAsync(MqIntegrationEvent @event)
    {
        var id = @event.Body;
        try
        {
            var data = await _store.ReadDataRequestAsync(id);
            var connectPartyRequest = XmlSerializerUtility.Deserialize<ConnectPartyRequest>(data);
            if (connectPartyRequest == null)
            {
                throw new ArgumentException("Invalid request.");
            }
            var response = await _service.FindConnectAsync(connectPartyRequest);
            var responseContent = XmlSerializerUtility.Serialize(response);

            await _store.SaveDataResponseAsync(id, responseContent);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task FindPartyBusinessUnitAsync(MqIntegrationEvent @event)
    {
        var id = @event.Body;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var businessUnitPartyRequest = XmlSerializerUtility.Deserialize<BusinessUnitPartyRequest>(data);
            if (businessUnitPartyRequest == null)
            {
                throw new ArgumentException("Invalid request.");
            }

            var response = await _service.FindBusinessUnitAsync(businessUnitPartyRequest);
            var responseContent = XmlSerializerUtility.Serialize(response);

            await _store.SaveDataResponseAsync(id, responseContent);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
            _logger.LogDebug(id, ex, "EXCEPTION DEBUG: {message}", ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task FindPartyPersonAsync(MqIntegrationEvent @event)
    {
        var id = @event.Body;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var personPartyRequest = XmlSerializerUtility.Deserialize<PersonPartyRequest>(data);
            if (personPartyRequest == null)
            {
                throw new ArgumentException("Invalid request.");
            }

            var response = await _service.FindPersonAsync(personPartyRequest);
            var responseContent = XmlSerializerUtility.Serialize(response);

            await _store.SaveDataResponseAsync(id, responseContent);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
            _logger.LogDebug(id, ex, "EXCEPTION DEBUG: {message}", ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task FindPartyDepartmentAsync(MqIntegrationEvent @event)
    {
        var id = @event.Body;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var departmentPartyRequest = XmlSerializerUtility.Deserialize<DepartmentPartyRequest>(data);
            if (departmentPartyRequest == null)
            {
                throw new ArgumentException("Invalid request.");
            }

            var response = await _service.FindDepartmentAsync(departmentPartyRequest);
            var responseContent = XmlSerializerUtility.Serialize(response);

            await _store.SaveDataResponseAsync(id, responseContent);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
            _logger.LogDebug(id, ex, "EXCEPTION DEBUG: {message}", ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task FindPartyJobTitleAsync(MqIntegrationEvent @event)
    {
        var id = @event.Body;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var jobTitlePartyRequest = XmlSerializerUtility.Deserialize<JobTitlePartyRequest>(data);
            if (jobTitlePartyRequest == null)
            {
                throw new ArgumentException("Invalid request.");
            }

            var response = await _service.FindJobTitleAsync(jobTitlePartyRequest);
            var responseContent = XmlSerializerUtility.Serialize(response);

            await _store.SaveDataResponseAsync(id, responseContent);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
            _logger.LogDebug(id, ex, "EXCEPTION DEBUG: {message}", ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task FindPartyEmployeeAsync(MqIntegrationEvent @event)
    {
        var id = @event.Body;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var employeePartyRequest = XmlSerializerUtility.Deserialize<EmployeePartyRequest>(data);
            if (employeePartyRequest == null)
            {
                throw new ArgumentException("Invalid request.");
            }

            var response = await _service.FindEmployeeAsync(employeePartyRequest);
            var responseContent = XmlSerializerUtility.Serialize(response);

            await _store.SaveDataResponseAsync(id, responseContent);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
            _logger.LogDebug(id, ex, "EXCEPTION DEBUG: {message}", ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task FindPartyDocTypeKindAsync(MqIntegrationEvent @event)
    {
        var id = @event.Body;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var docTypeKindPartyRequest = XmlSerializerUtility.Deserialize<DocTypeKindPartyRequest>(data);
            if (docTypeKindPartyRequest == null)
            {
                throw new ArgumentException("Invalid request.");
            }

            var response = await _service.FindDocTypeKindAsync(docTypeKindPartyRequest);
            var responseContent = XmlSerializerUtility.Serialize(response);

            await _store.SaveDataResponseAsync(id, responseContent);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
            _logger.LogDebug(id, ex, "EXCEPTION DEBUG: {message}", ex.Message);
        }
    }

    public async Task FindPartyPackagesAsync(MqIntegrationEvent @event)
    {
        var id = @event.Body;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var PackagesPartyRequest = XmlSerializerUtility.Deserialize<PostPackages>(data);
            if (PackagesPartyRequest == null)
            {
                throw new ArgumentException("Invalid request.");
            }
            var response = await _service.FindPackagesAsync(PackagesPartyRequest);
            var responseContent = XmlSerializerUtility.Serialize(response);

            await _store.SaveDataResponseAsync(id, responseContent);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);
            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
            _logger.LogDebug(id, ex, "EXCEPTION DEBUG: {message}", ex.Message);
        }
    }

    public async Task FindPartyBatchSyncAsync(MqIntegrationEvent @event)
    {
        var id = @event.Body;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var batchSyncRequest = XmlSerializerUtility.Deserialize<PostBatchSync>(data);
            if (batchSyncRequest == null)
            {
                throw new ArgumentException("Invalid request.");
            }
            var response = await _service.FindBatchSyncAsync(batchSyncRequest);
            var responseContent = XmlSerializerUtility.Serialize(response);

            await _store.SaveDataResponseAsync(id, responseContent);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);
            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
            _logger.LogDebug(id, ex, "EXCEPTION DEBUG: {message}", ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task FindPartyPackagesLifeCycleStateAsync(MqIntegrationEvent @event)
    {
        var id = @event.Body;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var packagesLifeCycle = XmlSerializerUtility.Deserialize<PostPackagesLifeCycle>(data);
            if (packagesLifeCycle == null)
            {
                throw new ArgumentException("Invalid request.");
            }
            var response = await _service.FindPackagesLifeCycleAsync(packagesLifeCycle);
            var responseContent = XmlSerializerUtility.Serialize(response);

            await _store.SaveDataResponseAsync(id, responseContent);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
            _logger.LogDebug(id, ex, "EXCEPTION DEBUG: {message}", ex.Message);
        }
    }

    public async Task FindPartyUserTokenAsync(MqIntegrationEvent @event)
    {
        var id = @event.Body;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var UserTokenRequest = XmlSerializerUtility.Deserialize<UserTokenPartyRequest>(data);
            if (UserTokenRequest == null)
            {
                throw new ArgumentException("Invalid request.");
            }
            var response = await _service.FindUserTokenAsync(UserTokenRequest.Authorization);
            var responseContent = XmlSerializerUtility.Serialize(response);

            await _store.SaveDataResponseAsync(id, responseContent);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
            _logger.LogDebug(id, ex, "EXCEPTION DEBUG: {message}", ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task FindPartyContractCategoryAsync(MqIntegrationEvent @event)
    {
        var id = @event.Body;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var сontractCategoryPartyRequest = XmlSerializerUtility.Deserialize<DrxContractCategoriesPartyRequest>(data);
            if (сontractCategoryPartyRequest == null)
            {
                throw new ArgumentException("Invalid request.");
            }

            var response = await _service.FindContractCategoryAsync(сontractCategoryPartyRequest);
            var responseContent = XmlSerializerUtility.Serialize(response);

            await _store.SaveDataResponseAsync(id, responseContent);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
            _logger.LogDebug(id, ex, "EXCEPTION DEBUG: {message}", ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task FindPartyDocumentRegisterAsync(MqIntegrationEvent @event)
    {
        var id = @event.Body;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var documentRegisterPartyRequest = XmlSerializerUtility.Deserialize<DrxDocumentRegisterPartyRequest>(data);
            if (documentRegisterPartyRequest == null)
            {
                throw new ArgumentException("Invalid request.");
            }

            var response = await _service.FindDocumentRegisterAsync(documentRegisterPartyRequest);
            var responseContent = XmlSerializerUtility.Serialize(response);

            await _store.SaveDataResponseAsync(id, responseContent);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
            _logger.LogDebug(id, ex, "EXCEPTION DEBUG: {message}", ex.Message);
        }
    }
}

