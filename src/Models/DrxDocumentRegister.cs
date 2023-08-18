// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Services.DirectumRx.Api.Models;

/// <summary>
/// Represents a request body to DirectumRX.
/// </summary>
[XmlRoot(ElementName = "DrxDocumentRegisterPartyRequest")]

public class DrxDocumentRegisterPartyRequest
{
    /// <summary>
    /// Gets or sets of the authorization header.
    /// </summary>
    [XmlElement(ElementName = "Authorization")]
    public Authorization? Authorization { get; set; }
}

/// <summary>
/// Represents an Company.
/// </summary>
[XmlRoot(ElementName = "DrxDocumentRegisterRequest")]

public class DrxDocumentRegisterRequest
{
    /// <summary>
    /// Gets or sets the identifier of the contract categories.
    /// </summary>
    [JsonPropertyName("value")]
    [XmlArray(ElementName = "DocumentRegisters")]
    [XmlArrayItem(ElementName = "DocumentRegister")]
    public List<DocumentRegister> DocumentRegisters { get; set; }

}

/// <summary>
/// Represents an Person.
/// </summary>
[XmlRoot(ElementName = "DocumentRegister")]
public class DocumentRegister
{
    /// <summary>
    /// Gets or sets the identifier of the document register.
    /// </summary>
    [JsonPropertyName("Id")]
    [XmlElement(ElementName = "Id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the document register name.
    /// </summary>
    [JsonPropertyName("Name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the document register status.
    /// </summary>
    [JsonPropertyName("Status")]
    [XmlElement(ElementName = "Status")]
    public string Status { get; set; }
}
