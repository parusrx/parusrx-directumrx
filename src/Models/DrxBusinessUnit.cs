// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents a request body to DirectumRX.
/// </summary>
[XmlRoot(ElementName = "DrxBusinessUnitPartyRequest")]

public class BusinessUnitPartyRequest
{
    /// <summary>
    /// Gets or sets of the authorization header.
    /// </summary>
    [XmlElement(ElementName = "Authorization")]
    public Authorization? Authorization { get; set; }
}

/// <summary>
/// Represents an Company.
/// </summary>
[XmlRoot(ElementName = "DrxBusinessUnitRequest")]

public class DrxBusinessUnitRequest
{
    /// <summary>
    /// Gets or sets the identifier of the company.
    /// </summary>
    [JsonPropertyName("value")]
    [XmlArray(ElementName = "BusinessUnits")]
    [XmlArrayItem(ElementName = "BusinessUnit")]
    public List<DrxBusinessUnit> Companies { get; set; }

}

/// <summary>
/// Represents an Department.
/// </summary>
[XmlRoot(ElementName = "BusinessUnit")]

public class DrxBusinessUnit
{
    /// <summary>
    /// Gets or sets the identifier of the company.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the guid of the company.
    /// </summary>
    [JsonPropertyName("Sid")]
    [XmlElement(ElementName = "Sid")]
    public string Sid { get; set; }

    /// <summary>
    /// Gets or sets the department name.
    /// </summary>
    [JsonPropertyName("Name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the department status.
    /// </summary>
    [JsonPropertyName("Status")]
    [XmlElement(ElementName = "Status")]
    public string Status { get; set; }
}
