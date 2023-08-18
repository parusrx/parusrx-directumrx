// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Services.DirectumRx.Api.Models;

/// <summary>
/// Represents an JobTitle.
/// </summary>
[XmlRoot(ElementName = "JobTitle")]
public class DrxJobTitle
{
    /// <summary>
    /// Gets or sets the identifier of the job title.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the job title name.
    /// </summary>
    [JsonPropertyName("Name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }
}
