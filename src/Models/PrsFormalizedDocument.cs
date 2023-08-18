// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Services.DirectumRx.Api.Models;

/// <summary>
/// Formalized document
/// </summary>
[XmlRoot("FormalizedDocument")]

public class FormalizedDocument
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
    /// XML - file structure
    /// </summary>
    [XmlElement(ElementName = "XmlFormalizedDocument")]
    public string XmlFormalizedDocument { get; set; }
}
