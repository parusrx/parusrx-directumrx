// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents a request body to DirectumRX.
/// </summary>
[XmlRoot(ElementName = "DrxContractCategoriesPartyRequest")]

public class DrxContractCategoriesPartyRequest
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
[XmlRoot(ElementName = "DrxContractCategoriesRequest")]

public class DrxContractCategoriesRequest
{
    /// <summary>
    /// Gets or sets the identifier of the contract categories.
    /// </summary>
    [JsonPropertyName("value")]
    [XmlArray(ElementName = "ContractCategories")]
    [XmlArrayItem(ElementName = "ContractCategory")]
    public List<ContractCategory> ContractCategories { get; set; }

}

/// <summary>
/// Represents an contract category.
/// </summary>
[XmlRoot(ElementName = "ContractCategory")]

public class ContractCategory
{
    /// <summary>
    /// Gets or sets the identifier of the company.
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
    /// Gets or sets the department status.
    /// </summary>
    [JsonPropertyName("Status")]
    [XmlElement(ElementName = "Status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the contract categories.
    /// </summary>
    [JsonPropertyName("DocumentKinds")]
    [XmlArray(ElementName = "CategoryDocumentKinds")]
    [XmlArrayItem(ElementName = "DocumentKinds")]
    public List<DocumentKindId> DocumentKinds { get; set; }
}

/// <summary>
/// Represents an document kind.
/// </summary>
[XmlRoot(ElementName = "DocumentKind")]

public class DocumentKindId
{
    /// <summary>
    /// Post the identifier of the document kind.
    /// </summary>
    [JsonPropertyName("DocumentKind")]
    [XmlElement(ElementName = "DocumentKind")]
    public DocumentKindPost DocumentKind { get; set; }
}
