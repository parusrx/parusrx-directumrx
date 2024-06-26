﻿// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents an Departmen.
/// </summary>
[XmlRoot("Currency")]

public class Currency
{
    /// <summary>
    /// Gets or sets the name of the currency.
    /// </summary>
    [JsonPropertyName("Name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the alpha code of the currency.
    /// </summary>
    [JsonPropertyName("AlphaCode")]
    [XmlElement(ElementName = "AlphaCode")]
    public string AlphaCode { get; set; }
    /// <summary>
    /// Gets or sets the short name of the currency.
    /// </summary>
    [JsonPropertyName("ShortName")]
    [XmlElement(ElementName = "ShortName")]
    public string ShortName { get; set; }

    /// <summary>
    /// Gets or sets the fraction name of the currency.
    /// </summary>
    [JsonPropertyName("FractionName")]
    [XmlElement(ElementName = "FractionName")]
    public string FractionName { get; set; }
    /// <summary>
    /// Gets or sets the numeric code of the currency.
    /// </summary>
    [JsonPropertyName("NumericCode")]
    [XmlElement(ElementName = "NumericCode")]
    public string NumericCode { get; set; }
}
