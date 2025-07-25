// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents a request body to DirectumRX.
/// </summary>
[XmlRoot(ElementName = "DrxDepartmentPartyRequest")]

public class DepartmentPartyRequest
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
/// Represents an Department.
/// </summary>
[XmlRoot(ElementName = "DrxDepartmentRequest")]

public class DrxDepartmentRequest
{
    /// <summary>
    /// Gets or sets the identifier of the departments.
    /// </summary>
    [JsonPropertyName("value")]
    [XmlArray(ElementName = "Departments")]
    [XmlArrayItem(ElementName = "Department")]
    public List<DrxDepartmentSync> Department { get; set; }

}

/// <summary>
/// Represents an Departmen.
/// </summary>
[XmlRoot(ElementName = "Department")]

public class DrxDepartment
{
    /// <summary>
    /// Gets or sets the identifier of the department.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the department name.
    /// </summary>
    [JsonPropertyName("Name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the business unit of the departmen.
    /// </summary>
    [JsonPropertyName("BusinessUnit")]
    [XmlElement(ElementName = "BusinessUnit")]
    public DrxBusinessUnit BusinessUnit { get; set; }
}

/// <summary>
/// Represents an Departmen.
/// </summary>
[XmlRoot(ElementName = "Department")]

public class DrxDepartmentSync
{
    /// <summary>
    /// Gets or sets the identifier of the department.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the department name.
    /// </summary>
    [JsonPropertyName("Name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the department status.
    /// </summary>
    [JsonPropertyName("Status")]
    [XmlElement(ElementName = "Status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the business unit of the departmen.
    /// </summary>
    [JsonPropertyName("BusinessUnit")]
    [XmlElement(ElementName = "BusinessUnit")]
    public DrxBusinessUnitId BusinessUnit { get; set; }
}

/// <summary>
/// Represents an Departmen.
/// </summary>
[XmlRoot(ElementName = "Department")]

public class DrxDepartmentId
{
    /// <summary>
    /// Gets or sets the identifier of the department.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }
}