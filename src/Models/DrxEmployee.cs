// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents a request body to DirectumRX.
/// </summary>
[XmlRoot(ElementName = "DrxEmployeePartyRequest")]

public class EmployeePartyRequest
{
    /// <summary>
    /// Gets or sets of the authorization header.
    /// </summary>
    [XmlElement(ElementName = "Authorization")]
    public Authorization? Authorization { get; set; }

    /// <summary>
    /// Gets or sets of the authorization header.
    /// </summary>
    [XmlElement(ElementName = "BusinessUnit")]
    public int? BusinessUnit { get; set; }
}

/// <summary>
/// Represents a status connection.
/// </summary>
[XmlRoot(ElementName = "DrxEmployeeRequest")]

public class DrxEmployeeRequest
{
    /// <summary>
    /// Gets or sets the identifier of the company.
    /// </summary>
    [JsonPropertyName("value")]
    [XmlArray(ElementName = "Employees")]
    [XmlArrayItem(ElementName = "Employee")]
    public List<DrxEmployee> Employees { get; set; }
}

/// <summary>
/// Represents an Employee.
/// </summary>
[XmlRoot(ElementName = "Employee")]
public class DrxEmployee
{
    /// <summary>
    /// Gets or sets the identifier of the employee.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the employee.
    /// </summary>
    [JsonPropertyName("Name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the personnel number of the employee.
    /// </summary>
    [JsonPropertyName("PersonnelNumber")]
    [XmlElement(ElementName = "PersonnelNumber")]
    public string PersonnelNumber { get; set; }

    /// <summary>
    /// Gets or sets the status of the employee.
    /// </summary>
    [JsonPropertyName("Status")]
    [XmlElement(ElementName = "Status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the login of the employee.
    /// </summary>
    [JsonPropertyName("Login")]
    [XmlElement(ElementName = "Login")]
    public DrxLogin Login { get; set; }

    /// <summary>
    /// Gets or sets the department of the employee.
    /// </summary>
    [JsonPropertyName("Department")]
    [XmlElement(ElementName = "Department")]
    public DrxDepartment Department { get; set; }

    /// <summary>
    /// Gets or sets the job title of the employee.
    /// </summary>
    [JsonPropertyName("JobTitle")]
    [XmlElement(ElementName = "JobTitle")]
    public DrxJobTitle JobTitle { get; set; }

    /// <summary>
    /// Gets or sets the person of the employee.
    /// </summary>
    [JsonPropertyName("Person")]
    [XmlElement(ElementName = "Person")]
    public DrxPerson Person { get; set; }
}
