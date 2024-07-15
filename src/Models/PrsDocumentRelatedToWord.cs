// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Document Related To Work
/// </summary>
[XmlRoot("DocRelatedToWork")]

public class DocRelatedToWork
{
    /// <summary>
    /// Document identification number
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public long Id { get; set; }
    /// <summary>
    /// Document registration number Parus 8
    /// </summary>
    [JsonPropertyName("Rn")]
    [XmlElement(ElementName = "Rn")]
    public long Rn { get; set; }
    /// <summary>
    /// Master document
    /// </summary>
    [JsonPropertyName("Master")]
    [XmlElement(ElementName = "Master")]
    public bool Master { get; set; }
    /// <summary>
    /// Id document kind
    /// </summary>
    [JsonPropertyName("DocumentKind")]
    [XmlElement(ElementName = "DocumentKind")]
    public long DocumentKind { get; set; }
    /// <summary>
    /// Subject
    /// </summary>
    [JsonPropertyName("Subject")]
    [XmlElement(ElementName = "Subject")]
    public string Subject { get; set; }
    /// <summary>
    /// Registration number
    /// </summary>
    [JsonPropertyName("RegistrationNumber")]
    [XmlElement(ElementName = "RegistrationNumber")]
    public string RegistrationNumber { get; set; }
    /// <summary>
    /// Registration date
    /// </summary>
    [JsonPropertyName("RegistrationDate")]
    [XmlElement(ElementName = "RegistrationDate")]
    public DateTime RegistrationDate { get; set; }
    /// <summary>
    /// Document
    /// </summary>
    [JsonPropertyName("Document")]
    [XmlElement(ElementName = "Document")]
    public Document Document { get; set; }
}