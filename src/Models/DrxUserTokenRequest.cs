// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents a request body to DirectumRX.
/// </summary>
[XmlRoot(ElementName = "DrxUserTokenPartyRequest")]

public class UserTokenPartyRequest
{
    /// <summary>
    /// Gets or sets of the authorization header.
    /// </summary>
    [XmlElement(ElementName = "Authorization")]
    public Authorization? Authorization { get; set; }
}

/// <summary>
/// Represents a user token.
/// </summary>
[XmlRoot(ElementName = "DrxUserTokenRequest")]
public class DrxUserTokenRequest
{
    /// <summary>
    /// Gets user token.
    /// </summary>
    [XmlElement(ElementName = "Token")]
    public string Token { get; set; }
    /// <summary>
    /// Gets user token.
    /// </summary>
    [XmlElement(ElementName = "State")]
    public int State { get; set; }
}
