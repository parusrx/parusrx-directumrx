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

/// <summary>
/// Represents an EmployeeModel .
/// </summary>
[XmlRoot(ElementName = "EmployeeModel ")]
public class EmployeeModel
{
    /// <summary>
    /// Gets or sets the additional properties of the employee.
    /// </summary>
    [JsonPropertyName("ObjectExtension")]
    [XmlElement(ElementName = "ObjectExtension")]
    public string ObjectExtension { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the employee.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or sets the external id of the employee.
    /// </summary>
    [JsonPropertyName("ExternalId")]
    [XmlElement(ElementName = "ExternalId")]
    public string ExternalId { get; set; }

    /// <summary>
    /// Gets or sets the person external id of the employee.
    /// </summary>
    [JsonPropertyName("PersonExternalId")]
    [XmlElement(ElementName = "PersonExternalId")]
    public string PersonExternalId { get; set; }

    /// <summary>
    /// Gets or sets the job title external id of the employee.
    /// </summary>
    [JsonPropertyName("JobTitleExternalId")]
    [XmlElement(ElementName = "JobTitleExternalId")]
    public string JobTitleExternalId { get; set; }

    /// <summary>
    /// Gets or sets the department external id of the employee.
    /// </summary>
    [JsonPropertyName("DepartmentExternalId")]
    [XmlElement(ElementName = "DepartmentExternalId")]
    public string DepartmentExternalId { get; set; }

    /// <summary>
    /// Gets or sets the personal phone of the employee.
    /// </summary>
    [JsonPropertyName("PersonalPhone")]
    [XmlElement(ElementName = "PersonalPhone")]
    public string PersonalPhone { get; set; }

    /// <summary>
    /// Gets or sets the notification email of the employee.
    /// </summary>
    [JsonPropertyName("NotificationEmail")]
    [XmlElement(ElementName = "NotificationEmail")]
    public string NotificationEmail { get; set; }

    /// <summary>
    /// Gets or sets the employment type of the employee.
    /// </summary>
    [JsonPropertyName("EmploymentType")]
    [XmlElement(ElementName = "EmploymentType")]
    public string EmploymentType { get; set; }

    /// <summary>
    /// Gets or sets the personal account status of the employee.
    /// </summary>
    [JsonPropertyName("PersonalAccountStatus")]
    [XmlElement(ElementName = "PersonalAccountStatus")]
    public string PersonalAccountStatus { get; set; }

    /// <summary>
    /// Gets or sets the personnel number of the employee.
    /// </summary>
    [JsonPropertyName("PersonnelNumber")]
    [XmlElement(ElementName = "PersonnelNumber")]
    public string PersonnelNumber { get; set; }
}