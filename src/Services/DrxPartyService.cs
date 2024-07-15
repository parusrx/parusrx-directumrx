// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using Microsoft.Extensions.Logging;

namespace ParusRx.DirectumRx.Services;

/// <summary>
/// The default implementation of <see cref="DrxPartyService"/>.
/// </summary>
public class DrxPartyService : IDrxPartyService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly ILogger<DrxPartyService> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="DrxPartyService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    /// <param name="settings">The DirectumRX settings.</param>
    /// <param name="logger">The logger to use.</param>
    public DrxPartyService(HttpClient httpClient, IOptions<DrxSettings> settings,
        ILogger<DrxPartyService> logger)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task<DrxConnectCheckingRequest> FindConnectAsync(ConnectPartyRequest connectionsRequest)
    {
        var authorizationBytes = Encoding.UTF8.GetBytes($"{connectionsRequest?.Authorization?.Username}:{connectionsRequest?.Authorization?.Password}");
        var request = new HttpRequestMessage(HttpMethod.Get, $"{connectionsRequest?.Authorization?.Host}/odata/Integration/GetConnectChecking");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authorizationBytes));
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DrxConnectCheckingRequest>(options: _jsonSerializerOptions);
    }

    /// <inheritdoc/>
    public async Task<DrxBusinessUnitRequest> FindBusinessUnitAsync(BusinessUnitPartyRequest connectionsRequest)
    {
        var authorizationBytes = Encoding.UTF8.GetBytes($"{connectionsRequest?.Authorization?.Username}:{connectionsRequest?.Authorization?.Password}");
        var request = new HttpRequestMessage(HttpMethod.Get, $"{connectionsRequest?.Authorization?.Host}/odata/IBusinessUnits?$select=Id,Sid,Name,Status");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authorizationBytes));
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DrxBusinessUnitRequest>(options: _jsonSerializerOptions);
    }

    /// <inheritdoc/>
    public async Task<DrxEmployeeRequest> FindEmployeeAsync(EmployeePartyRequest connectionsRequest)
    {
        var authorizationBytes = Encoding.UTF8.GetBytes($"{connectionsRequest?.Authorization?.Username}:{connectionsRequest?.Authorization?.Password}");
        var request = new HttpRequestMessage(HttpMethod.Get, $"{connectionsRequest?.Authorization?.Host}/odata/IEmployees?$filter=Status eq 'Active' and Department/BusinessUnit/Id eq {connectionsRequest?.BusinessUnit.Value} &$select=Id,Name,PersonnelNumber,Status&$expand=Login($select=Id,LoginName),Department($select=Id,Name),Department($expand=BusinessUnit($select=Id,Sid,Name,Status)),JobTitle($select=Id,Name),Person($select=Id,LastName,FirstName,MiddleName)");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authorizationBytes));
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DrxEmployeeRequest>(options: _jsonSerializerOptions);
    }

    /// <inheritdoc/>
    public async Task<DrxDocumentTypeKind> FindDocTypeKindAsync(DocTypeKindPartyRequest connectionsRequest)
    {
        var authorizationBytes = Encoding.UTF8.GetBytes($"{connectionsRequest?.Authorization?.Username}:{connectionsRequest?.Authorization?.Password}");
        var request = new HttpRequestMessage(HttpMethod.Get, $"{connectionsRequest?.Authorization?.Host}/odata/IDocumentKinds?$select=Id,Status,ShortName,Name,IsDefault&$expand=DocumentType($select=Id,Status,Name,DocumentTypeGuid)");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authorizationBytes));
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DrxDocumentTypeKind>(options: _jsonSerializerOptions);
    }

    /// <inheritdoc/>
    public async Task<PackagesLifeCycle> FindPackagesAsync(PostPackages packages)
    {
        var content = new StringContent(JsonSerializer.Serialize(packages.PackagesDto, _jsonSerializerOptions), Encoding.UTF8, "application/json");
        //_logger.LogInformation(content.ReadAsStringAsync().Result);
        var request = new HttpRequestMessage(HttpMethod.Post, $"{packages.Authorization?.Host}/odata/Integration/PostPackages");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", packages.Authorization?.Token);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Content = content;

        var response = await _httpClient.SendAsync(request);
        var packagesLifeCycle = new PackagesLifeCycle();
        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            packagesLifeCycle.PackageLifeCycle.Add(new PackageLifeCycle() { Rn = 0, Status = 0, Error = "Unauthorized", DocumentsLifeCycle = new List<DocumentLifeCycle>() });
            return packagesLifeCycle;
        }
        else
            response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<PackagesLifeCycle>(options: _jsonSerializerOptions);
    }

    /// <inheritdoc/>
    public async Task<PackagesLifeCycle> FindPackagesLifeCycleAsync(PostPackagesLifeCycle packages)
    {
        var content = new StringContent(JsonSerializer.Serialize(packages.PackagesLifeCycleDto, _jsonSerializerOptions), Encoding.UTF8, "application/json");
        var authorizationBytes = Encoding.UTF8.GetBytes($"{packages.Authorization?.Username}:{packages.Authorization?.Password}");
        var request = new HttpRequestMessage(HttpMethod.Post, $"{packages.Authorization?.Host}/odata/Integration/PackagesLifeCycle");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authorizationBytes));
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Content = content;

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<PackagesLifeCycle>(options: _jsonSerializerOptions);
    }

    /// <inheritdoc/>
    public async Task<DrxUserTokenRequest> FindUserTokenAsync(Authorization authorization)
    {
        var authorizationBytes = Encoding.UTF8.GetBytes($"{authorization?.Username}:{authorization?.Password}");
        var request = new HttpRequestMessage(HttpMethod.Get, $"{authorization?.Host}/token");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authorizationBytes));
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await _httpClient.SendAsync(request);

        var userToken = new DrxUserTokenRequest();
        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            userToken.State = 0;
            userToken.Token = "Unauthorized";
        }

        else if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            userToken.State = 1;
            userToken.Token = response.Content.ReadAsStringAsync().Result;
        }

        else
            response.EnsureSuccessStatusCode();

        return userToken;
    }

    /// <inheritdoc/>
    public async Task<DrxContractCategoriesRequest> FindContractCategoryAsync(DrxContractCategoriesPartyRequest connectionsRequest)
    {
        var authorizationBytes = Encoding.UTF8.GetBytes($"{connectionsRequest?.Authorization?.Username}:{connectionsRequest?.Authorization?.Password}");
        var request = new HttpRequestMessage(HttpMethod.Get, $"{connectionsRequest?.Authorization?.Host}/odata/IContractCategories?$select=Id,Name,Status&$expand=DocumentKinds($select=DocumentKind;$expand=DocumentKind($select=Id))");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authorizationBytes));
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DrxContractCategoriesRequest>(options: _jsonSerializerOptions);
    }

    /// <inheritdoc/>
    public async Task<DrxDocumentRegisterRequest> FindDocumentRegisterAsync(DrxDocumentRegisterPartyRequest connectionsRequest)
    {
        var authorizationBytes = Encoding.UTF8.GetBytes($"{connectionsRequest?.Authorization?.Username}:{connectionsRequest?.Authorization?.Password}");
        var request = new HttpRequestMessage(HttpMethod.Get, $"{connectionsRequest?.Authorization?.Host}/odata/IDocumentRegisters?$select=Id,Name,Status");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authorizationBytes));
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DrxDocumentRegisterRequest>(options: _jsonSerializerOptions);
    }

    /// <inheritdoc/>
    public async Task<DrxExchangeQueueItems> FindExchangeQueueItemAsync(AuthorizationDrxEQI authorization)
    {
        var authorizationBytes = Encoding.UTF8.GetBytes($"{authorization?.Username}:{authorization?.Password}");
        var request = new HttpRequestMessage(HttpMethod.Get, $"{authorization.Host}/odata/Integration/GetExchangeQueueItems(BusinessUnit={authorization.BusinessUnitId})");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authorizationBytes));
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _httpClient.SendAsync(request);
        var exchangeQueueItems = new DrxExchangeQueueItems();
        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
        {
            return null;
        }
        else
            response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DrxExchangeQueueItems>(options: _jsonSerializerOptions);
    }

    /// <inheritdoc/>
    public async Task PostExchangeQueueItemAsync(AuthorizationDrxEQI authorization, long exchangeQueueItemId, long packegeParusRn)
    {
        //int ExchangeQueueItemId, int PackegeParusR
        var authorizationBytes = Encoding.UTF8.GetBytes($"{authorization?.Username}:{authorization?.Password}");
        var request = new HttpRequestMessage(HttpMethod.Post, $"{authorization.Host}/odata/Integration/PostExchangeQueueItemStatus");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authorizationBytes));
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var content = new
        {
            exchangeQueueItemId,
            packegeParusRn
        };

        request.Content = new StringContent(JsonSerializer.Serialize(content, _jsonSerializerOptions), Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }
}
