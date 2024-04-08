// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents an document type and kind.
/// </summary>
[XmlRoot(ElementName = "DrxDocumentTypeKindRequest")]

public class DrxDocumentTypeKind
{
    /// <summary>
    /// Gets or sets document types and kinds.
    /// </summary>
    [JsonPropertyName("value")]
    [XmlArray(ElementName = "DocumentKinds")]
    [XmlArrayItem(ElementName = "DocumentKind")]
    public List<DrxDocumentKind> DocumentKind { get; set; }

}

/// <summary>
/// Represents a request body to DirectumRX.
/// </summary>
[XmlRoot(ElementName = "DrxDocumentTypeKindPartyRequest")]

public class DocTypeKindPartyRequest
{
    /// <summary>
    /// Gets or sets of the authorization header.
    /// </summary>
    [XmlElement(ElementName = "Authorization")]
    public Authorization? Authorization { get; set; }
}

/// <summary>
/// Represents an document kind.
/// </summary>
[XmlRoot(ElementName = "DocumentKind")]

public class DrxDocumentKind
{
    /// <summary>
    /// Gets or sets the identifier of the document kind.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the document kind name.
    /// </summary>
    [JsonPropertyName("Name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the short name of the document kind.
    /// </summary>
    [JsonPropertyName("ShortName")]
    [XmlElement(ElementName = "ShortName")]
    public string Guid { get; set; }

    /// <summary>
    /// Gets or sets the document kind status.
    /// </summary>
    [JsonPropertyName("Status")]
    [XmlElement(ElementName = "Status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the document kind is default.
    /// </summary>
    [JsonPropertyName("IsDefault")]
    [XmlElement(ElementName = "IsDefault")]
    public bool IsDefault { get; set; }

    /// <summary>
    /// Gets or sets the document type related to document kind
    /// </summary>
    [JsonPropertyName("DocumentType")]
    [XmlElement(ElementName = "DocumentType")]
    public DrxDocumentType DocumentType { get; set; }
}

/// <summary>
/// Represents an document kind.
/// </summary>
[XmlRoot(ElementName = "DocumentKind")]

public class DocumentKindPost
{
    /// <summary>
    /// Post the identifier of the document kind.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }
}

/// <summary>
/// Represents an document type.
/// </summary>
[XmlRoot(ElementName = "DocumentType")]

public class DrxDocumentType
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
    [JsonPropertyName("DocumentTypeGuid")]
    [XmlElement(ElementName = "DocumentTypeGuid")]
    public string Guid { get; set; }

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
