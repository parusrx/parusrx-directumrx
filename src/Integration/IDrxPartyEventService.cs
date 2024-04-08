// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using ParusRx.EventBus;

namespace ParusRx.DirectumRx.Integration;

/// <summary>
/// Defines methods for connect parties.
/// </summary>
public interface IDrxPartyEventService
{
    /// <summary>
    /// Serialize the connection party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task FindPartyConnectAsync(MqIntegrationEvent request);

    /// <summary>
    /// Serialize the companies party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task FindPartyBusinessUnitAsync(MqIntegrationEvent request);

    /// <summary>
    /// Serialize the employee party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task FindPartyEmployeeAsync(MqIntegrationEvent request);

    /// <summary>
    /// Serialize the document type and kind party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task FindPartyDocTypeKindAsync(MqIntegrationEvent request);

    /// <summary>
    /// Serialize the documents packages party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task FindPartyPackagesAsync(MqIntegrationEvent request);

    /// <summary>
    /// Serialize the documents packages party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    //Task FindPartyPackagesLifeCycleAsync(MqIntegrationEvent request);

    /// <summary>
    /// Serialize the incoming document state party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task FindPartyPackagesLifeCycleStateAsync(MqIntegrationEvent request);

    /// <summary>
    /// Serialize the user token party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task FindPartyUserTokenAsync(MqIntegrationEvent request);

    /// <summary>
    /// Serialize the contract categories party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task FindPartyContractCategoryAsync(MqIntegrationEvent request);

    /// <summary>
    /// Serialize the document register party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="MqIntegrationEvent"/>.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task FindPartyDocumentRegisterAsync(MqIntegrationEvent request);
}
