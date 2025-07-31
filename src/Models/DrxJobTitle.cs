// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents a request body to DirectumRX.
/// </summary>
[XmlRoot(ElementName = "DrxJobTitlePartyRequest")]

public class JobTitlePartyRequest
{
    /// <summary>
    /// Gets or sets of the authorization header.
    /// </summary>
    [XmlElement(ElementName = "Authorization")]
    public Authorization? Authorization { get; set; }
}

/// <summary>
/// Represents an JobTitle.
/// </summary>
[XmlRoot(ElementName = "DrxJobTitleRequest")]

public class DrxJobTitleRequest
{
    /// <summary>
    /// Gets or sets the identifier of the JobTitle.
    /// </summary>
    [JsonPropertyName("value")]
    [XmlArray(ElementName = "JobTitles")]
    [XmlArrayItem(ElementName = "JobTitle")]
    public List<DrxJobTitleSync> JobTitle { get; set; }

}

/// <summary>
/// Represents an JobTitle.
/// </summary>
[XmlRoot(ElementName = "JobTitle")]
public class DrxJobTitleSync
{
    /// <summary>
    /// Gets or sets the identifier of the job title.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the job title status.
    /// </summary>
    [JsonPropertyName("Status")]
    [XmlElement(ElementName = "Status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the job title name.
    /// </summary>
    [JsonPropertyName("Name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the job title external Id.
    /// </summary>
    [JsonPropertyName("ExternalId")]
    [XmlElement(ElementName = "ExternalId")]
    public string ExternalId { get; set; }

    /// <summary>
    /// Gets or sets the job title department.
    /// </summary>
    [JsonPropertyName("Department")]
    [XmlElement(ElementName = "Department")]
    public DrxDepartment Department { get; set; }
}

/// <summary>
/// Represents an JobTitle.
/// </summary>
[XmlRoot(ElementName = "JobTitle")]
public class DrxJobTitle
{
    /// <summary>
    /// Gets or sets the identifier of the job title.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }
}
