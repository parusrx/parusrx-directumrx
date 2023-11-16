// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents an document type and kind.
/// </summary>
[XmlRoot(ElementName = "DrxExchangeQueueItemRequest")]
public class DrxExchangeQueueItems
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("value")]
    [XmlArray(ElementName = "DrxExchangeQueueItems")]
    [XmlArrayItem(ElementName = "DrxExchangeQueueItem")]
    public List<DrxExchangeQueueItem> ExchangeQueueItems { get; set; }
}

public class DrxExchangeQueueItem
{
    /// <summary>
    /// Identifier
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public long Id { get; set; }
    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName("Name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }
    /// <summary>
    /// Identifier business unit
    /// </summary>
    [JsonPropertyName("BusinessUnitId")]
    [XmlElement(ElementName = "BusinessUnitId")]
    public long BusinessUnitId { get; set; }
    /// <summary>
    /// Counterparty TIN
    /// </summary>
    [JsonPropertyName("CounterpartyTIN")]
    [XmlElement(ElementName = "CounterpartyTIN")]
    public string CounterpartyTIN { get; set; }
    /// <summary>
    /// Counterparty TRRC
    /// </summary>
    [JsonPropertyName("CounterpartyTRRC")]
    [XmlElement(ElementName = "CounterpartyTRRC")]
    public string CounterpartyTRRC { get; set; }
    /// <summary>
    /// Identifier employee
    /// </summary>
    [JsonPropertyName("EmployeeId")]
    [XmlElement(ElementName = "EmployeeId")]
    public long EmployeeId { get; set; }
    /// <summary>
    /// Attacheds
    ///</summary>
    [JsonPropertyName("Attacheds")]
    [XmlElement(ElementName = "Attacheds")]
    public List<ExchangeQueueItemDocument> Attacheds { get; set; }
    /// <summary>
    /// Status
    /// </summary>
    [JsonPropertyName("Status")]
    [XmlElement(ElementName = "Status")]
    public string Status { get; set; }
    /// <summary>
    /// Note
    /// </summary>
    [JsonPropertyName("Note")]
    [XmlElement(ElementName = "Note")]
    public string Note { get; set; }
}

public class ExchangeQueueItemDocument
{
    /// <summary>
    /// Identifier document
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public long Id { get; set; }
    /// <summary>
    /// Main document
    /// </summary>
    [JsonPropertyName("Main")]
    [XmlElement(ElementName = "Main")]
    public int Main { get; set; }
    /// <summary>
    /// Name document
    /// </summary>
    [JsonPropertyName("Name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }
    /// <summary>
    /// Identifier document type
    /// </summary>

    [JsonPropertyName("DocumentTypeId")]
    [XmlElement(ElementName = "DocumentTypeId")]
    public long DocumentTypeId { get; set; }
    /// <summary>
    /// Identifier document kind
    /// </summary>

    [JsonPropertyName("DocumentKindId")]

    [XmlElement(ElementName = "DocumentKindId")]
    public long DocumentKindId { get; set; }
    /// <summary>
    /// Identifier document group
    /// </summary>
    [JsonPropertyName("DocumentGroupId")]
    [XmlElement(ElementName = "DocumentGroupId")]
    public long? DocumentGroupId { get; set; }
    /// <summary>
    /// Identifier document register
    /// </summary>
    [JsonPropertyName("DocumentRegisterId")]
    [XmlElement(ElementName = "DocumentRegisterId")]
    public long? DocumentRegisterId { get; set; }
    /// <summary>
    /// Life cycle state
    /// </summary>
    [JsonPropertyName("LifeCycleState")]
    [XmlElement(ElementName = "LifeCycleState")]
    public string LifeCycleState { get; set; }
    /// <summary>
    /// Internal approval state
    /// </summary>
    [JsonPropertyName("InternalApprovalState")]
    [XmlElement(ElementName = "InternalApprovalState")]
    public string InternalApprovalState { get; set; }
    /// <summary>
    /// Last version approved
    /// </summary>
    [JsonPropertyName("LastVersionApproved")]
    [XmlElement(ElementName = "LastVersionApproved")]
    public bool? LastVersionApproved { get; set; }
    /// <summary>
    /// External approval state
    /// </summary>
    [JsonPropertyName("ExternalApprovalState")]
    [XmlElement(ElementName = "ExternalApprovalState")]
    public string ExternalApprovalState { get; set; }
    /// <summary>
    /// Link card document
    /// </summary>
    [JsonPropertyName("Link")]
    [XmlElement(ElementName = "Link")]
    public string Link { get; set; }
    /// <summary>
    /// Nate
    /// </summary>
    [JsonPropertyName("Note")]
    [XmlElement(ElementName = "Note")]
    public string Note { get; set; }
    /// <summary>
    /// XML - body
    /// </summary>
    [JsonPropertyName("Body")]
    [XmlElement(ElementName = "Body")]
    public byte[] Body { get; set; }
}

/// <summary>
/// Represents the link and header of the authorization request for DirectumRX.
/// </summary>
public class AuthorizationDrxEQI
{
    /// <summary>
    /// Connect Rn
    /// </summary>
    public long ConnectRn { get; set; }
    /// <summary>
    /// Gets or sets of the Host.
    /// </summary>
    public string Host { get; set; }
    /// <summary>
    /// Gets or sets of the Username.
    /// </summary>
    public string Username { get; set; }
    /// <summary>
    /// Gets or sets of the Password.
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    /// Business unit Rn
    /// </summary>
    public long BusinessUnitRn { get; set; }
    /// <summary>
    /// Company
    /// </summary>
    public long Company { get; set; }
    /// <summary>
    /// Business unit Id
    /// </summary>
    public long BusinessUnitId { get; set; }
    /// <summary>
    /// Legal person
    /// </summary>
    public long Jurpers { get; set; }
    

}
