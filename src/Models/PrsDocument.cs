﻿// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents an Departmen.
/// </summary>
[XmlRoot("Document")]

public class Document
{
    /// <summary>
    /// Gets or sets the file name of the company.
    /// </summary>
    [JsonPropertyName("FileName")]
    [XmlElement(ElementName = "FileName")]
    public string FileName { get; set; }
    /// <summary>
    /// Gets or sets the content of the company.
    /// </summary>
    [JsonPropertyName("Content")]
    [XmlElement(ElementName = "Content")]
    public string Content { get; set; }
}
