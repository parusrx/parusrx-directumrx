// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents an Departmen.
/// </summary>
[XmlRoot(ElementName = "Departmen")]

public class DrxDepartment
{
    /// <summary>
    /// Gets or sets the identifier of the department.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the department name.
    /// </summary>
    [JsonPropertyName("Name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the business unit of the departmen.
    /// </summary>
    [JsonPropertyName("BusinessUnit")]
    [XmlElement(ElementName = "BusinessUnit")]
    public DrxBusinessUnit BusinessUnit { get; set; }
}
