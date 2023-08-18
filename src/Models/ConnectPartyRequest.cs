// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Services.DirectumRx.Api.Models;

/// <summary>
/// Represents a request body to DirectumRX.
/// </summary>
[XmlRoot(ElementName = "DrxConnectPartyRequest")]

public class ConnectPartyRequest
{
    /// <summary>
    /// Gets or sets of the authorization header.
    /// </summary>
    [XmlElement(ElementName = "Authorization")]
    public Authorization? Authorization { get; set; }
}

/// <summary>
/// Represents a status connection.
/// </summary>
[XmlRoot(ElementName = "DrxConnectCheckingRequest")]
public class DrxConnectCheckingRequest
{
    /// <summary>
    /// Gets status of the connect.
    /// </summary>
    [JsonPropertyName("value")]
    [XmlElement(ElementName = "Value")]
    public string Value { get; set; }
}
