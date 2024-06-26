﻿// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

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
