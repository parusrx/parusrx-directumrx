// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DirectumRx.Models;

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

