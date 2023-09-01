// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Incoming Invoice.
/// </summary>
[XmlRoot("IncomingInvoice")]

public class IncomingInvoice
{
    /// <summary>
    /// Gets or sets the identifier of the PayAccIn.
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
    public string DocumentKind { get; set; }
    /// <summary>
    /// Subject
    /// </summary>
    [JsonPropertyName("Subject")]
    [XmlElement(ElementName = "Subject")]
    public string Subject { get; set; }
    /// <summary>
    /// Gets or sets the pref and numb of the PayAccIn.
    /// </summary>
    [JsonPropertyName("PrefNumb")]
    [XmlElement(ElementName = "PrefNumb")]
    public string PrefNumb { get; set; }
    /// <summary>
    /// Gets or sets the date of the PayAccIn.
    /// </summary>
    [JsonPropertyName("Date")]
    [XmlElement(ElementName = "Date")]
    public DateTime? Date { get; set; }
    /// <summary>
    /// Gets or sets the number of the PayAccIn.
    /// </summary>
    [JsonPropertyName("Number")]
    [XmlElement(ElementName = "Number")]
    public string Number { get; set; }
    /// <summary>
    /// Gets or sets the RegDate of the PayAccIn.
    /// </summary>
    [JsonPropertyName("RegDate")]
    [XmlElement(ElementName = "RegDate")]
    public DateTime? RegDate { get; set; }
    /// <summary>
    /// Gets or sets the total amount of the PayAccIn.
    /// </summary>
    [JsonPropertyName("TotalAmount")]
    [XmlElement(ElementName = "TotalAmount")]
    public double? TotalAmount { get; set; }
    /// <summary>
    /// Gets or sets the note of the PayAccIn.
    /// </summary>
    [JsonPropertyName("Note")]
    [XmlElement(ElementName = "Note")]
    public string Note { get; set; }
    /// <summary>
    /// Gets or sets the Currency of the PayAccIn.
    /// </summary>
    [JsonPropertyName("Currency")]
    [XmlElement(ElementName = "Currency")]
    public Currency Currency { get; set; }
    /// <summary>
    /// Gets or sets the Counterparty of the PayAccIn.
    /// </summary>
    [JsonPropertyName("Counterparty")]
    [XmlElement(ElementName = "Counterparty")]
    public Counterparty Counterparty { get; set; }
    /// <summary>
    /// Gets or sets the Contract of the PayAccIn.
    /// </summary>
    [JsonPropertyName("Contract")]
    [XmlElement(ElementName = "Contract")]
    public ContractNumb? Contract { get; set; }
    /// <summary>
    /// Gets or sets the Document of the PayAccIn.
    /// </summary>
    [JsonPropertyName("Document")]
    [XmlElement(ElementName = "Document")]
    public Document Document { get; set; }
}
