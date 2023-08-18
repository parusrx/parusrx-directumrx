// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Services.DirectumRx.Api.Models;

/// <summary>
/// Represents an Person.
/// </summary>
[XmlRoot(ElementName = "Login")]
public class DrxLogin
{
    /// <summary>
    /// Gets or sets the identifier of the login.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the Login name of the login.
    /// </summary>
    [JsonPropertyName("LoginName")]
    [XmlElement(ElementName = "LoginName")]
    public string LoginName { get; set; }
}
