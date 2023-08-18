// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Services.DirectumRx.Api.Models;

/// <summary>
/// Addendum document
/// </summary>
[XmlRoot("AddendumDocument")]

public class AddendumDocument
{
    /// <summary>
    /// Document identification number
    /// </summary>
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }
    /// <summary>
    /// Document registration number Parus 8
    /// </summary>
    [XmlElement(ElementName = "Rn")]
    public long Rn { get; set; }
    /// <summary>
    /// Master document
    /// </summary>
    [XmlElement(ElementName = "Master")]
    public bool Master { get; set; }
    /// <summary>
    /// Id document kind
    /// </summary>
    [XmlElement(ElementName = "DocumentKind")]
    public int DocumentKind { get; set; }
    /// <summary>
    /// Subject
    /// </summary>
    [XmlElement(ElementName = "Subject")]
    public string Subject { get; set; }
    /// <summary>
    /// Document
    /// </summary>
    [XmlElement(ElementName = "Document")]
    public Document Document { get; set; }
}
