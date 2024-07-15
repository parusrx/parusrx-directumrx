// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents an Contract(registration number and date).
/// </summary>
[XmlRoot("Contract")]

public class ContractNumb
{
    /// <summary>
    /// Gets or sets the registration number of the contract.
    /// </summary>
    [JsonPropertyName("RegistrationNumber")]
    [XmlElement(ElementName = "RegistrationNumber")]
    public string RegistrationNumber { get; set; }

    /// <summary>
    /// Gets or sets the registration date of the contract.
    /// </summary>
    [JsonPropertyName("RegistrationDate")]
    [XmlElement(ElementName = "RegistrationDate")]
    public DateTime RegistrationDate { get; set; }
}

/// <summary>
/// Represents an Contract.
/// </summary>
[XmlRoot("Contract")]

public class Contract
{
    /// <summary>
    /// Gets or sets the identifier of the Contract.
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
    /// Id document group
    /// </summary>
    [JsonPropertyName("DocumentGroup")]
    [XmlElement(ElementName = "DocumentGroup")]
    public long DocumentGroup { get; set; }
    /// <summary>
    /// Subject of the Contract
    /// </summary>
    [JsonPropertyName("Subject")]
    [XmlElement(ElementName = "Subject")]
    public string Subject { get; set; }
    /// <summary>
    /// Gets or sets the total amount of the Contract.
    /// </summary>
    [JsonPropertyName("TotalAmount")]
    [XmlElement(ElementName = "TotalAmount")]
    public double? TotalAmount { get; set; }
    /// <summary>
    /// Gets or sets the registration date valid from of the Contract.
    /// </summary>
    [JsonPropertyName("ValidFrom")]
    [XmlElement(ElementName = "ValidFrom")]
    public DateTime? ValidFrom { get; set; }
    /// <summary>
    /// Gets or sets the registration date valid till of the Contract.
    /// </summary>
    [JsonPropertyName("ValidTill")]
    [XmlElement(ElementName = "ValidTill")]
    public DateTime? ValidTill { get; set; }
    /// <summary>
    /// Gets or sets the note of the Contract.
    /// </summary>
    [JsonPropertyName("Note")]
    [XmlElement(ElementName = "Note")]
    public string Note { get; set; }
    /// <summary>
    /// Gets or sets the registration date of the Contract.
    /// </summary>
    [JsonPropertyName("RegDate")]
    [XmlElement(ElementName = "RegDate")]
    public DateTime? RegDate { get; set; }
    /// <summary>
    /// Gets or sets the registration number of the Contract.
    /// </summary>
    [JsonPropertyName("RegNumb")]
    [XmlElement(ElementName = "RegNumb")]
    public string RegNumb { get; set; }
    /// <summary>
    /// Gets or sets the Currency of the Contract.
    /// </summary>
    [JsonPropertyName("Currency")]
    [XmlElement(ElementName = "Currency")]
    public Currency Currency { get; set; }
    /// <summary>
    /// Gets or sets the Counterparty of the Contract.
    /// </summary>
    [JsonPropertyName("Counterparty")]
    [XmlElement(ElementName = "Counterparty")]
    public Counterparty Counterparty { get; set; }
    /// <summary>
    /// Gets or sets the Document of the Contract.
    /// </summary>
    [JsonPropertyName("Document")]
    [XmlElement(ElementName = "Document")]
    public Document Document { get; set; }
}
