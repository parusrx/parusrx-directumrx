﻿// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Outgoing Invoice.
/// </summary>
[XmlRoot("OutgoingInvoice")]

public class OutgoingInvoice
{
    /// <summary>
    /// Gets or sets the identifier of the Outgoing Invoices.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public string Id { get; set; }
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
    public int DocumentKind { get; set; }
    /// <summary>
    /// Gets or sets the pref and numb of the Outgoing Invoices.
    /// </summary>
    [JsonPropertyName("PrefNumb")]
    [XmlElement(ElementName = "PrefNumb")]
    public string PrefNumb { get; set; }
    /// <summary>
    /// Gets or sets the RegDate of the Outgoing Invoices.
    /// </summary>
    [JsonPropertyName("RegDate")]
    [XmlElement(ElementName = "RegDate")]
    public DateTime? RegDate { get; set; }
    /// <summary>
    /// Gets or sets the total amount of the Outgoing Invoices.
    /// </summary>
    [JsonPropertyName("TotalAmount")]
    [XmlElement(ElementName = "TotalAmount")]
    public double? TotalAmount { get; set; }
    /// <summary>
    /// Gets or sets the note of the Outgoing Invoices.
    /// </summary>
    [JsonPropertyName("Note")]
    [XmlElement(ElementName = "Note")]
    public string Note { get; set; }
    /// <summary>
    /// Gets or sets the Currency of the Outgoing Invoices.
    /// </summary>
    [JsonPropertyName("Currency")]
    [XmlElement(ElementName = "Currency")]
    public Currency Currency { get; set; }
    /// <summary>
    /// Gets or sets the Counterparty of the Outgoing Invoices.
    /// </summary>
    [JsonPropertyName("Counterparty")]
    [XmlElement(ElementName = "Counterparty")]
    public Counterparty Counterparty { get; set; }
    /// <summary>
    /// Gets or sets the Contract of the Outgoing Invoices.
    /// </summary>
    [JsonPropertyName("Contract")]
    [XmlElement(ElementName = "Contract")]
    public ContractNumb? Contract { get; set; }
    /// <summary>
    /// Gets or sets the Document of the Outgoing Invoices.
    /// </summary>
    [JsonPropertyName("Document")]
    [XmlElement(ElementName = "Document")]
    public Document Document { get; set; }
}
