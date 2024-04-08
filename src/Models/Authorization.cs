// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
