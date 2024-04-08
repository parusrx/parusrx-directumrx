// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

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
