// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Packages of documents from Parus 8
/// </summary>
[XmlRoot("DrxPackagesPartyRequest")]
public class PostPackages
{
    [XmlElement(ElementName = "Authorization")]
    public Authorization Authorization { get; set; }
    [XmlElement(ElementName = "PackagesDto")]
    public PackagesDto PackagesDto { get; set; }
}

[XmlRoot("PackagesDto")]
public class PackagesDto
{
    [JsonPropertyName("Packages")]
    public Packages Packages { get; set; }
}

/// <summary>
/// Packages of documents from Parus 8
/// </summary>
[XmlRoot("Packages")]
public class Packages
{
    [JsonPropertyName("PackageDocuments")]
    [XmlArray(ElementName = "PackageDocuments")]
    [XmlArrayItem(ElementName = "PackageDocument")]
    public List<PackageDocument> PackageDocuments { get; set; }
}

/// <summary>
/// Package of documents from Parus 8
/// </summary>
[XmlRoot("PackageDocument")]
public class PackageDocument
{
    /// <summary>
    /// Package registration number Parus 8
    /// </summary>
    [JsonPropertyName("Rn")]
    [XmlElement(ElementName = "Rn")]
    public long Rn { get; set; }
    /// <summary>
    /// Task
    /// </summary>
    [JsonPropertyName("Task")]
    [XmlElement(ElementName = "Task")]
    public int Task { get; set; }
    /// <summary>
    /// Service information(Businessunit, Employee, Departament)
    /// </summary>
    [JsonPropertyName("SysData")]
    [XmlElement(ElementName = "SysData")]
    public SysData SysData { get; set; }
    /// <summary>
    /// Contracts
    /// </summary>
    [JsonPropertyName("Contracts")]
    [XmlArray(ElementName = "Contracts")]
    [XmlArrayItem(ElementName = "Contract")]
    public List<Contract>? Contracts { get; set; }
    /// <summary>
    /// Formalized documents
    /// </summary>
    [JsonPropertyName("FormalizedDocuments")]
    [XmlArray(ElementName = "FormalizedDocuments")]
    [XmlArrayItem(ElementName = "FormalizedDocument")]
    public List<FormalizedDocument>? FormalizedDocuments { get; set; }
    /// <summary>
    /// Accounting documents
    /// </summary>
    [JsonPropertyName("AccountingDocuments")]
    [XmlArray(ElementName = "AccountingDocuments")]
    [XmlArrayItem(ElementName = "AccountingDocument")]
    public List<AccountingDocument>? AccountingDocuments { get; set; }
    /// <summary>
    /// Addendum documents
    ///</summary>
    [JsonPropertyName("AddendumDocuments")]
    [XmlArray(ElementName = "AddendumDocuments")]
    [XmlArrayItem(ElementName = "AddendumDocument")]
    public List<AddendumDocument>? AddendumDocuments { get; set; }
    /// <summary>
    /// Incoming invoices
    ///</summary>
    [JsonPropertyName("IncomingInvoices")]
    [XmlArray(ElementName = "IncomingInvoices")]
    [XmlArrayItem(ElementName = "IncomingInvoice")]
    public List<IncomingInvoice>? IncomingInvoices { get; set; }
    /// <summary>
    /// Outgoing invoices
    ///</summary>
    [JsonPropertyName("OutgoingInvoices")]
    [XmlArray(ElementName = "OutgoingInvoices")]
    [XmlArrayItem(ElementName = "OutgoingInvoice")]
    public List<OutgoingInvoice>? OutgoingInvoices { get; set; }
    /// <summary>
    /// Waybill
    ///</summary>
    [JsonPropertyName("Waybills")]
    [XmlArray(ElementName = "Waybills")]
    [XmlArrayItem(ElementName = "Waybill")]
    public List<Waybill>? Waybills { get; set; }
    /// <summary>
    /// Contract Statement
    ///</summary>
    [JsonPropertyName("ContractStatements")]
    [XmlArray(ElementName = "ContractStatements")]
    [XmlArrayItem(ElementName = "ContractStatement")]
    public List<ContractStatement>? ContractStatements { get; set; }
    /// <summary>
    /// Document related to works
    ///</summary>
    [JsonPropertyName("DocRelatedToWorks")]
    [XmlArray(ElementName = "DocRelatedToWorks")]
    [XmlArrayItem(ElementName = "DocRelatedToWork")]
    public List<DocRelatedToWork>? DocRelatedToWorks { get; set; }
}

