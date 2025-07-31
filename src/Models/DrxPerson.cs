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

