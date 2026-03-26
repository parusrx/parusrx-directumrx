// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents an SysData.
/// </summary>
[XmlRoot("SysData")]

public class SysData
{
    /// <summary>
    /// Gets or sets the send variant of the system data.
    /// </summary>
    [JsonPropertyName("SendVariant")]
    [XmlElement(ElementName = "SendVariant")]
    public string SendVariant { get; set; }
    /// <summary>
    /// Gets or sets the author Id of the system data.
    /// </summary>
    [JsonPropertyName("AuthorId")]
    [XmlElement(ElementName = "AuthorId")]
    public long AuthorId { get; set; }
    /// <summary>
    /// Gets or sets the task comment of the system data.
    /// </summary>
    [JsonPropertyName("TaskComment")]
    [XmlElement(ElementName = "TaskComment")]
    public string TaskComment { get; set; }
    /// <summary>
    /// Gets or sets the pepared Id of the system data.
    /// </summary>
    [JsonPropertyName("PreparedId")]
    [XmlElement(ElementName = "PreparedId")]
    public long PreparedId { get; set; }
    /// <summary>
    /// Gets or sets the business unit of the system data.
    /// </summary>
    [JsonPropertyName("BusinessUnit")]
    [XmlElement(ElementName = "BusinessUnit")]
    public long? BusinessUnit { get; set; }

    /// <summary>
    /// Gets or sets the signatory.
    /// </summary>
    [JsonPropertyName("Signatory")]
    [XmlElement(ElementName = "Signatory")]
    public long? Signatory { get; set; }

    /// <summary>
    /// Gets or sets the req. approvers.
    /// </summary>
    [JsonPropertyName("ReqApprovers")]
    [XmlArray(ElementName = "ReqApprovers")]
    [XmlArrayItem(ElementName = "ReqApprover")]
    public List<Approvers>? ReqApprovers { get; set; }

    /// <summary>
    /// Gets or sets of add approvers.
    /// </summary>
    [JsonPropertyName("AddApprovers")]
    [XmlArray(ElementName = "AddApprovers")]
    [XmlArrayItem(ElementName = "AddApprover")]
    public List<Approvers>? AddApprovers { get; set; }
}

/// <summary>
/// Gets or sets of approvers
/// </summary>
[XmlRoot("Employee")]
public class Approvers
{
    /// <summary>
    /// Gets or sets the id employee.
    /// </summary>
    [JsonPropertyName("Employee")]
    [XmlElement(ElementName = "Employee")]
    public long Employee { get; set; }
}