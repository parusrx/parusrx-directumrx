﻿// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Services.DirectumRx.Api.Models;

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
