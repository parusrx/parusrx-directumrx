﻿// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Contract Statement.
/// </summary>
[XmlRoot("ContractStatement")]

public class ContractStatement
{
    /// <summary>
    /// Gets or sets the identifier of the Contract Statement.
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
    /// Gets or sets the pref and numb of the Contract Statement.
    /// </summary>
    [JsonPropertyName("PrefNumb")]
    [XmlElement(ElementName = "PrefNumb")]
    public string PrefNumb { get; set; }
    /// <summary>
    /// Gets or sets the RegDate of the Contract Statement.
    /// </summary>
    [JsonPropertyName("RegDate")]
    [XmlElement(ElementName = "RegDate")]
    public DateTime? RegDate { get; set; }
    /// <summary>
    /// Gets or sets the total amount of the Contract Statement.
    /// </summary>
    [JsonPropertyName("TotalAmount")]
    [XmlElement(ElementName = "TotalAmount")]
    public double? TotalAmount { get; set; }
    /// <summary>
    /// Gets or sets the note of the Contract Statement.
    /// </summary>
    [JsonPropertyName("Note")]
    [XmlElement(ElementName = "Note")]
    public string Note { get; set; }
    /// <summary>
    /// Gets or sets the Currency of the Contract Statement.
    /// </summary>
    [JsonPropertyName("Currency")]
    [XmlElement(ElementName = "Currency")]
    public Currency Currency { get; set; }
    /// <summary>
    /// Gets or sets the Counterparty of the Contract Statement.
    /// </summary>
    [JsonPropertyName("Counterparty")]
    [XmlElement(ElementName = "Counterparty")]
    public Counterparty Counterparty { get; set; }
    /// <summary>
    /// Gets or sets the Contract of the Contract Statement.
    /// </summary>
    [JsonPropertyName("Contract")]
    [XmlElement(ElementName = "Contract")]
    public ContractNumb? Contract { get; set; }
    /// <summary>
    /// Gets or sets the Document of the Contract Statement.
    /// </summary>
    [JsonPropertyName("Document")]
    [XmlElement(ElementName = "Document")]
    public Document Document { get; set; }
}
