// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents an Departmen.
/// </summary>
[XmlRoot("SysData")]

public class SysData
{
    /// <summary>
    /// Gets or sets the business unit of the system data.
    /// </summary>
    [JsonPropertyName("BusinessUnit")]
    [XmlElement(ElementName = "BusinessUnit")]
    public long? BusinessUnit { get; set; }
    /// <summary>
    /// Gets or sets the employee of the system data.
    /// </summary>
    [JsonPropertyName("Employee")]
    [XmlElement(ElementName = "Employee")]
    public long? Employee { get; set; }
    /// <summary>
    /// Gets or sets the department of the system data.
    /// </summary>
    [JsonPropertyName("Department")]
    [XmlElement(ElementName = "Department")]
    public long? Department { get; set; }
    /// <summary>
    /// Gets or sets the job title of the system data.
    /// </summary>
    [JsonPropertyName("JobTitle")]
    [XmlElement(ElementName = "JobTitle")]
    public long? JobTitle { get; set; }
    /// <summary>
    /// Gets or sets the login of the system data.
    /// </summary>
    [JsonPropertyName("Login")]
    [XmlElement(ElementName = "Login")]
    public long? Login { get; set; }

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