// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents an .
/// </summary>
[XmlRoot("DocumentLifeCycle")]
public class DocumentLifeCycle
{
    /// <summary>
    /// Document identification number.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }
    /// <summary>
    /// Document registration number Parus 8.
    /// </summary>
    [JsonPropertyName("Rn")]
    [XmlElement(ElementName = "Rn")]
    public long Rn { get; set; }
    /// <summary>
    /// Status of the document.
    /// </summary>
    [JsonPropertyName("Status")]
    [XmlElement(ElementName = "Status")]
    public int Status { get; set; }
    /// <summary>
    /// Life cycle state the document.
    /// </summary>
    [JsonPropertyName("LifeCycleState")]
    [XmlElement(ElementName = "LifeCycleState")]
    public string LifeCycleState { get; set; }
    /// <summary>
    /// Internal approval state the document.
    /// </summary>
    [JsonPropertyName("InternalApprovalState")]
    [XmlElement(ElementName = "InternalApprovalState")]
    public string InternalApprovalState { get; set; }
    /// <summary>
    /// Approved the document.
    /// </summary>
    [JsonPropertyName("LastVersionApproved")]
    [XmlElement(ElementName = "LastVersionApproved")]
    public bool LastVersionApproved { get; set; } = false;
    /// <summary>
    /// External document approval status.
    /// </summary>
    [JsonPropertyName("ExternalApprovalState")]
    [XmlElement(ElementName = "ExternalApprovalState")]
    public string ExternalApprovalState { get; set; }
    /// <summary>
    /// Message to document.
    /// </summary>
    [JsonPropertyName("Message")]
    [XmlElement(ElementName = "Message")]
    public string Message { get; set; }
    /// <summary>
    /// Link to the document.
    /// </summary>
    [JsonPropertyName("Link")]
    [XmlElement(ElementName = "Link")]
    public string Link { get; set; }
    
}

/// <summary>
/// Represent.
/// </summary>
[XmlRoot("ListDocumentLifeCycle")]

public class ListDocumentLifeCycle
{
    /// <summary>
    /// List of life cycles of documents.
    /// </summary>
    [JsonPropertyName("value")]
    [XmlArray(ElementName = "DocumentLifeCycles")]
    [XmlArrayItem(ElementName = "DocumentLifeCycle")]

    public List<DocumentLifeCycle> DocumentLifeCycles { get; set; }
}

/// <summary>
/// .
/// </summary>
[XmlRoot("PackagesLifeCycleDto")]

public class PackagesLifeCycle
{
    /// <summary>
    /// List of life cycles of packages documents.
    /// </summary>
    [JsonPropertyName("PackagesLifeCycle")]
    [XmlArray(ElementName = "PackagesLifeCycle")]
    [XmlArrayItem(ElementName = "PackageLifeCycle")]

    public List<PackageLifeCycle> PackageLifeCycle { get; set; } = new List<PackageLifeCycle>();
}

/// <summary>
/// .
/// </summary>
[XmlRoot("DrxPackageLifeCyclePartyRequest")]

public class PostPackagesLifeCycle
{
    /// <summary>
    /// Authorization.
    /// </summary>
    [JsonPropertyName("Authorization")]
    [XmlElement(ElementName = "Authorization")]
    public Authorization Authorization { get; set; } = new Authorization();
    /// <summary>
    /// Life cycles of packages documents.
    /// </summary>
    [JsonPropertyName("PackagesLifeCycleDto")]
    [XmlElement(ElementName = "PackagesLifeCycleDto")]
    public PackagesLifeCycle PackagesLifeCycleDto { get; set; } = new PackagesLifeCycle();
}

/// <summary>
/// State package and list of life cycles of documents.
/// </summary>
[XmlRoot("PackageLifeCycle")]

public class PackageLifeCycle
{
    /// <summary>
    /// Package registration number Parus 8.
    /// </summary>
    [JsonPropertyName("Rn")]
    [XmlElement(ElementName = "Rn")]
    public long Rn { get; set; }
    /// <summary>
    /// Status of the package
    /// </summary>
    [JsonPropertyName("Status")]
    [XmlElement(ElementName = "Status")]
    public int Status { get; set; }
    /// <summary>
    /// Error
    /// </summary>
    [JsonPropertyName("Error")]
    [XmlElement(ElementName = "Error")]
    public string Error { get; set; }
    /// <summary>
    /// List of life cycles of documents
    /// </summary>
    [JsonPropertyName("DocumentsLifeCycle")]
    [XmlArray(ElementName = "DocumentsLifeCycle")]
    [XmlArrayItem(ElementName = "DocumentLifeCycle")]

    public List<DocumentLifeCycle> DocumentsLifeCycle { get; set; } = new List<DocumentLifeCycle>();
}

public class PackageLifeCycleParus
{
    /// <summary>
    /// Package registration number Parus 8.
    /// </summary>
    [JsonPropertyName("Rn")]
    [XmlElement(ElementName = "Rn")]
    public long Rn { get; set; }
    /// <summary>
    /// Status of the package
    /// </summary>
    [JsonPropertyName("Status")]
    [XmlElement(ElementName = "Status")]
    public string Status { get; set; }
    /// <summary>
    /// Error
    /// </summary>
    [JsonPropertyName("Error")]
    [XmlElement(ElementName = "Error")]
    public string Error { get; set; }
}
