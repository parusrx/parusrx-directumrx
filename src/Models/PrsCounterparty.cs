// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents an Departmen.
/// </summary>
[XmlRoot("Counterparty")]

public class Counterparty
{
    /// <summary>
    /// Gets or sets the name of the company.
    /// </summary>
    [JsonPropertyName("Name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the TIN of the company.
    /// </summary>
    [JsonPropertyName("TIN")]
    [XmlElement(ElementName = "TIN")]
    public string TIN { get; set; }
    /// <summary>
    /// Gets or sets the lLegal address of the company.
    /// </summary>
    [JsonPropertyName("LegalAddress")]
    [XmlElement(ElementName = "LegalAddress")]
    public string LegalAddress { get; set; }

    /// <summary>
    /// Gets or sets the phones of the company.
    /// </summary>
    [JsonPropertyName("Phones")]
    [XmlElement(ElementName = "Phones")]
    public string Phones { get; set; }
    /// <summary>
    /// Gets or sets the email of the company.
    /// </summary>
    [JsonPropertyName("Email")]
    [XmlElement(ElementName = "Email")]
    public string Email { get; set; }
    /// <summary>
    /// Gets or sets the nonresident of the company.
    /// </summary>
    [JsonPropertyName("Nonresident")]
    [XmlElement(ElementName = "Nonresident")]
    public int? Nonresident { get; set; }
    /// <summary>
    /// Gets or sets the PSRN of the company.
    /// </summary>
    [JsonPropertyName("PSRN")]
    [XmlElement(ElementName = "PSRN")]
    public string PSRN { get; set; }
    /// <summary>
    /// Gets or sets the NCEO of the company.
    /// </summary>
    [JsonPropertyName("NCEO")]
    [XmlElement(ElementName = "NCEO")]
    public string NCEO { get; set; }
    /// <summary>
    /// Gets or sets the NCEA of the company.
    /// </summary>
    [JsonPropertyName("NCEA")]
    [XmlElement(ElementName = "NCEA")]
    public string NCEA { get; set; }
    /// <summary>
    /// Gets or sets the TRRC of the company.
    /// </summary>
    [JsonPropertyName("TRRC")]
    [XmlElement(ElementName = "TRRC")]
    public string TRRC { get; set; }
    /// <summary>
    /// Gets or sets the legal name of the company.
    /// </summary>
    [JsonPropertyName("LegalName")]
    [XmlElement(ElementName = "LegalName")]
    public string LegalName { get; set; }
}
