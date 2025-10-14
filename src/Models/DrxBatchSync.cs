// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System;

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Packages of documents from Parus 8
/// </summary>
[XmlRoot("DrxBatchSyncPartyRequest")]
public class PostBatchSync
{
    [XmlElement(ElementName = "Authorization")]
    public Authorization Authorization { get; set; }

    [XmlElement(ElementName = "HRPro")]
    public bool HRPro { get; set; }

    [XmlElement(ElementName = "BatchSync")]
    public BatchSync BatchSync { get; set; }
}

/// <summary>
/// Represents the reference and header of a batch organizational structure synchronization request for DirectumRX.
/// </summary>
[XmlRoot("BatchSync")]
public class BatchSync
{
    /// <summary>
    /// Gets or sets of the external system id.
    /// </summary>
    [JsonPropertyName("externalSystemId")]
    [XmlElement(ElementName = "externalSystemId")]
    public string externalSystemId { get; set; }

    /// <summary>
    /// Gets or sets of the people models.
    /// </summary>
    [JsonPropertyName("peopleModels")]
    [XmlArray(ElementName = "peopleModels")]
    [XmlArrayItem(ElementName = "PersonModel")]
    public List<PersonModel>? peopleModels { get; set; }

    /// <summary>
    /// Gets or sets of the business units models.
    /// </summary>
    [JsonPropertyName("businessUnitsModels")]
    [XmlArray(ElementName = "businessUnitsModels")]
    [XmlArrayItem(ElementName = "BusinessUnitModel")]
    public List<BusinessUnitModel>? businessUnitsModels { get; set; }

    /// <summary>
    /// Gets or sets of the departments models
    /// </summary>
    [JsonPropertyName("departmentsModels")]
    [XmlArray(ElementName = "departmentsModels")]
    [XmlArrayItem(ElementName = "DepartmentModel")]
    public List<DepartmentModel>? departmentsModels { get; set; }

    /// <summary>
    /// Gets or sets of the job titles models
    /// </summary>
    [JsonPropertyName("jobTitlesModels")]
    [XmlArray(ElementName = "jobTitlesModels")]
    [XmlArrayItem(ElementName = "JobTitleModel")]
    public List<JobTitleModel>? jobTitlesModels { get; set; }

    /// <summary>
    /// Gets or sets of the employees models
    /// </summary>
    [JsonPropertyName("employeesModels")]
    [XmlArray(ElementName = "employeesModels")]
    [XmlArrayItem(ElementName = "EmployeeModel")]
    public List<EmployeeModel>? employeesModels { get; set; }
}

    /// <summary>
    /// Represents the reference and header of result of batch synchronization for DirectumRX.
    /// </summary>
    [XmlRoot("BatchSyncResult")]
public class BatchSyncResult
{
    /// <summary>
    /// Gets or sets of result of synchronization the people.
    /// </summary>
    [JsonPropertyName("People")]
    [XmlArray(ElementName = "People")]
    [XmlArrayItem(ElementName = "Person")]
    public List<SyncResult> People { get; set; }

    /// <summary>
    /// Gets or sets of result of synchronization the business units.
    /// </summary>
    [JsonPropertyName("BusinessUnits")]
    [XmlArray(ElementName = "BusinessUnits")]
    [XmlArrayItem(ElementName = "BusinessUnit")]
    public List<SyncResult> BusinessUnits { get; set; }

    /// <summary>
    /// Gets or sets of result of synchronization the departments.
    /// </summary>
    [JsonPropertyName("Departments")]
    [XmlArray(ElementName = "Departments")]
    [XmlArrayItem(ElementName = "Department")]
    public List<SyncResult> Departments { get; set; }

    /// <summary>
    /// Gets or sets of result of synchronization the job titles.
    /// </summary>
    [JsonPropertyName("JobTitles")]
    [XmlArray(ElementName = "JobTitles")]
    [XmlArrayItem(ElementName = "JobTitle")]
    public List<SyncResult> JobTitles { get; set; }

    /// <summary>
    /// Gets or sets of result of synchronization the employees.
    /// </summary>
    [JsonPropertyName("Employees")]
    [XmlArray(ElementName = "Employees")]
    [XmlArrayItem(ElementName = "Employee")]
    public List<SyncResult> Employees { get; set; }
}

/// <summary>
/// Represents the reference and header of synchronization result for DirectumRX.
/// </summary>
[XmlRoot("SyncResult")]
public class SyncResult
{
    /// <summary>
    /// Gets or sets the synchronization result of the entity ID from the external system.
    /// </summary>
    [JsonPropertyName("ExternalId")]
    [XmlElement(ElementName = "ExternalId")]
    public string ExternalId { get; set; }

    /// <summary>
    /// Gets or sets the synchronization result in entity ID in Directum RX.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or sets the synchronization result.
    /// </summary>
    [JsonPropertyName("Result")]
    [XmlElement(ElementName = "Result")]
    public string Result { get; set; }

    /// <summary>
    /// Gets or sets the URL of a synchronized entity in Directum RX.
    /// </summary>
    [JsonPropertyName("Url")]
    [XmlElement(ElementName = "Url")]
    public string Url { get; set; }

    /// <summary>
    /// Gets or sets of result of synchronization the employees.
    /// </summary>
    [JsonPropertyName("Issues")]
    [XmlArray(ElementName = "Issues")]
    [XmlArrayItem(ElementName = "Issue")]
    public List<IssueInfo>? Issues { get; set; }
}

/// <summary>
/// Represents the reference and title of synchronization problems.
/// </summary>
[XmlRoot("IssueInfo")]
public class IssueInfo
{
    /// <summary>
    /// Gets or sets the name of the field where the error occurred.
    /// </summary>
    [JsonPropertyName("FieldName")]
    [XmlElement(ElementName = "FieldName")]
    public string FieldName { get; set; }

    /// <summary>
    /// Gets or sets the error description.
    /// </summary>
    [JsonPropertyName("Description")]
    [XmlElement(ElementName = "Description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the error occurred.
    /// </summary>
    [JsonPropertyName("OccurrenceDate")]
    [XmlElement(ElementName = "OccurrenceDate")]
    public DateTimeOffset? OccurrenceDate { get; set; }

    /// <summary>
    /// Gets or sets Whether a push error notification should be sent to the external system user responsible for integration.
    /// </summary>
    [JsonPropertyName("IsPushSentToResponsible")]
    [XmlElement(ElementName = "IsPushSentToResponsible")]
    public bool? IsPushSentToResponsible { get; set; }

    /// <summary>
    /// Gets or sets the identity of the entity in the accounting system.
    /// </summary>
    [JsonPropertyName("ExternalId")]
    [XmlElement(ElementName = "ExternalId")]
    public string ExternalId { get; set; }

    /// <summary>
    /// Gets or sets the entity type.
    /// </summary>
    [JsonPropertyName("ExtEntityType")]
    [XmlElement(ElementName = "ExtEntityType")]
    public string ExtEntityType { get; set; }
}