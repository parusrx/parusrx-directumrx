// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents the link and header of the authorization request for DirectumRX.
/// </summary>
[XmlRoot("Authorization")]
public class Authorization
{
    /// <summary>
    /// Gets or sets of the Host.
    /// </summary>
    [XmlElement(ElementName = "Host")]
    public string Host { get; set; }

    /// <summary>
    /// Gets or sets of the Username.
    /// </summary>
    [XmlElement(ElementName = "Username")]
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets of the Password.
    /// </summary>
    [XmlElement(ElementName = "Password")]
    public string Password { get; set; }

    /// <summary>
    /// Token
    /// </summary>
     [XmlElement(ElementName = "Token")]
    public string Token { get; set; }

    /// <summary>
    /// Token
    /// </summary>
    [XmlElement(ElementName = "Rn")]
    public long? Rn { get; set; }
}
