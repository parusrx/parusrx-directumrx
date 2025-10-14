// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DirectumRx.Models;

/// <summary>
/// Represents a request body to DirectumRX.
/// </summary>
[XmlRoot(ElementName = "DrxPersonPartyRequest")]

public class PersonPartyRequest
{
    /// <summary>
    /// Gets or sets of the authorization header.
    /// </summary>
    [XmlElement(ElementName = "Authorization")]
    public Authorization? Authorization { get; set; }
}

/// <summary>
/// Represents an Person.
/// </summary>
[XmlRoot(ElementName = "DrxPersonRequest")]

public class DrxPersonRequest
{
    /// <summary>
    /// Gets or sets the identifier of the person.
    /// </summary>
    [JsonPropertyName("value")]
    [XmlArray(ElementName = "Persons")]
    [XmlArrayItem(ElementName = "Person")]
    public List<DrxPersonSync> Person { get; set; }

}

/// <summary>
/// Represents an Person.
/// </summary>
[XmlRoot(ElementName = "Person")]
public class DrxPerson
{
    /// <summary>
    /// Gets or sets the identifier of the person.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the person LastName.
    /// </summary>
    [JsonPropertyName("LastName")]
    [XmlElement(ElementName = "LastName")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the person FirstName.
    /// </summary>
    [JsonPropertyName("FirstName")]
    [XmlElement(ElementName = "FirstName")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the person MiddleName.
    /// </summary>
    [JsonPropertyName("MiddleName")]
    [XmlElement(ElementName = "MiddleName")]
    public string MiddleName { get; set; }
}

/// <summary>
/// Represents an Person.
/// </summary>
[XmlRoot(ElementName = "Person")]
public class DrxPersonSync
{
    /// <summary>
    /// Gets or sets the identifier of the person.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the person LastName.
    /// </summary>
    [JsonPropertyName("LastName")]
    [XmlElement(ElementName = "LastName")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the person FirstName.
    /// </summary>
    [JsonPropertyName("FirstName")]
    [XmlElement(ElementName = "FirstName")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the person MiddleName.
    /// </summary>
    [JsonPropertyName("MiddleName")]
    [XmlElement(ElementName = "MiddleName")]
    public string MiddleName { get; set; }

    /// <summary>
    /// Gets or sets the person Sex.
    /// </summary>
    [JsonPropertyName("Sex")]
    [XmlElement(ElementName = "Sex")]
    public string Sex { get; set; }

    /// <summary>
    /// Gets or sets the person DateOfBirth.
    /// </summary>
    [JsonPropertyName("DateOfBirth")]
    [XmlElement(ElementName = "DateOfBirth")]
    public DateTimeOffset? DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets the person TIN.
    /// </summary>
    [JsonPropertyName("TIN")]
    [XmlElement(ElementName = "TIN")]
    public string TIN { get; set; }

    /// <summary>
    /// Gets or sets the person INILA.
    /// </summary>
    [JsonPropertyName("INILA")]
    [XmlElement(ElementName = "INILA")]
    public string INILA { get; set; }

    /// <summary>
    /// Gets or sets the person Status.
    /// </summary>
    [JsonPropertyName("Status")]
    [XmlElement(ElementName = "Status")]
    public string Status { get; set; }

}

[XmlRoot(ElementName = "PersonModel ")]
public class PersonModel
{
    /// <summary>
    /// Gets or sets the additional properties of the person.
    /// </summary>
    [JsonPropertyName("ObjectExtension")]
    [XmlElement(ElementName = "ObjectExtension")]
    public string ObjectExtension { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the person.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or sets the external id of the person.
    /// </summary>
    [JsonPropertyName("ExternalId")]
    [XmlElement(ElementName = "ExternalId")]
    public string ExternalId { get; set; }

    /// <summary>
    /// Gets or sets the status of the person.
    /// </summary>
    [JsonPropertyName("Status")]
    [XmlElement(ElementName = "Status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the last name  of the person.
    /// </summary>
    [JsonPropertyName("LastName")]
    [XmlElement(ElementName = "LastName")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the first name of the person.
    /// </summary>
    [JsonPropertyName("FirstName")]
    [XmlElement(ElementName = "FirstName")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the middle name of the person.
    /// </summary>
    [JsonPropertyName("MiddleName")]
    [XmlElement(ElementName = "MiddleName")]
    public string MiddleName { get; set; }

    /// <summary>
    /// Gets or sets the sex of the person.
    /// </summary>
    [JsonPropertyName("Sex")]
    [XmlElement(ElementName = "Sex")]
    public string Sex { get; set; }

    /// <summary>
    /// Gets or sets the date of birth of the person.
    /// </summary>
    [JsonPropertyName("DateOfBirth")]
    [XmlElement(ElementName = "DateOfBirth")]
    public DateTimeOffset? DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets the TIN of the person.
    /// </summary>
    [JsonPropertyName("TIN")]
    [XmlElement(ElementName = "TIN")]
    public string TIN { get; set; }

    /// <summary>
    /// Gets or sets the INILA of the person.
    /// </summary>
    [JsonPropertyName("INILA")]
    [XmlElement(ElementName = "INILA")]
    public string INILA { get; set; }

    /// <summary>
    /// Gets or sets the identity document of the person.
    /// </summary>
    [JsonPropertyName("IdentityDocument")]
    [XmlElement(ElementName = "IdentityDocument")]
    public IdentityDocument? IdentityDocument { get; set; }

    /// <summary>
    /// Gets or sets the is creating new of the person.
    /// </summary>
    [JsonPropertyName("IsCreatingNew")]
    [XmlElement(ElementName = "IsCreatingNew")]
    public bool IsCreatingNew { get; set; }
}

[XmlRoot(ElementName = "IdentityDocument")]
public class IdentityDocument
{
    /// <summary>
    /// Gets or sets the king of the identity document.
    /// </summary>
    [JsonPropertyName("Kind")]
    [XmlElement(ElementName = "Kind")]
    public string Kind { get; set; }
    /// <summary>
    /// Gets or sets the series of the identity document.
    /// </summary>
    [JsonPropertyName("Series")]
    [XmlElement(ElementName = "Series")]
    public string Series { get; set; }

    /// <summary>
    /// Gets or sets the number of the identity document.
    /// </summary>
    [JsonPropertyName("Number")]
    [XmlElement(ElementName = "Number")]
    public string Number { get; set; }

    /// <summary>
    /// Gets or sets the issue date of the identity document.
    /// </summary>
    [JsonPropertyName("IssueDate")]
    [XmlElement(ElementName = "IssueDate")]
    public DateTimeOffset? IssueDate { get; set; }

    /// <summary>
    /// Gets or sets the issued by of the identity document.
    /// </summary>
    [JsonPropertyName("IssuedBy")]
    [XmlElement(ElementName = "IssuedBy")]
    public string IssuedBy { get; set; }

    /// <summary>
    /// Gets or sets the issuer ID of the identity document.
    /// </summary>
    [JsonPropertyName("IssuerID")]
    [XmlElement(ElementName = "IssuerID")]
    public string IssuerID { get; set; }

    /// <summary>
    /// Gets or sets the expiration date of the identity document.
    /// </summary>
    [JsonPropertyName("ExpirationDate")]
    [XmlElement(ElementName = "ExpirationDate")]
    public DateTimeOffset? IssueExpirationDatedBy { get; set; }
}
