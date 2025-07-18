// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
/// Represents an BusinessUnit.
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
    /// Gets or sets the company name.
    /// </summary>
    [JsonPropertyName("Name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the company tin.
    /// </summary>
    [JsonPropertyName("Tin")]
    [XmlElement(ElementName = "Tin")]
    public string Tin { get; set; }

    /// <summary>
    /// Gets or sets the company trrc.
    /// </summary>
    [JsonPropertyName("Trrc")]
    [XmlElement(ElementName = "Trrc")]
    public string Trrc { get; set; }

    /// <summary>
    /// Gets or sets the company legal name.
    /// </summary>
    [JsonPropertyName("LegalName")]
    [XmlElement(ElementName = "LegalName")]
    public string LegalName { get; set; }
    

    /// <summary>
    /// Gets or sets the company status.
    /// </summary>
    [JsonPropertyName("Status")]
    [XmlElement(ElementName = "Status")]
    public string Status { get; set; }
}
