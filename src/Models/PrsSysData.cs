// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
    public int? BusinessUnit { get; set; }
    /// <summary>
    /// Gets or sets the employee of the system data.
    /// </summary>
    [JsonPropertyName("Employee")]
    [XmlElement(ElementName = "Employee")]
    public int? Employee { get; set; }
    /// <summary>
    /// Gets or sets the department of the system data.
    /// </summary>
    [JsonPropertyName("Department")]
    [XmlElement(ElementName = "Department")]
    public int? Department { get; set; }
    /// <summary>
    /// Gets or sets the job title of the system data.
    /// </summary>
    [JsonPropertyName("JobTitle")]
    [XmlElement(ElementName = "JobTitle")]
    public int? JobTitle { get; set; }
    /// <summary>
    /// Gets or sets the login of the system data.
    /// </summary>
    [JsonPropertyName("Login")]
    [XmlElement(ElementName = "Login")]
    public int? Login { get; set; }
}
