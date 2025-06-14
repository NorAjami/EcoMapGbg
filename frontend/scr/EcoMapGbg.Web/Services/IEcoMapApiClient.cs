using EcoMapGbg.Web.Models;

namespace EcoMapGbg.Web.Services;

public interface IEcoMapApiClient
{
    Task<List<LocationSummaryDto>> GetAllLocationsAsync();
    Task<GetNearbyLocationsResponse> GetNearbyLocationsAsync(GetNearbyLocationsRequest request);
    Task<CreateLocationResponse> CreateLocationAsync(CreateLocationRequest request);
}

public class EcoMapApiClient : IEcoMapApiClient
{
    private readonly HttpClient _httpClient;

    public EcoMapApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<LocationSummaryDto>> GetAllLocationsAsync()
    {
        var response = await _httpClient.GetAsync("api/locations");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<LocationSummaryDto>>() ?? new();
    }

    public async Task<GetNearbyLocationsResponse> GetNearbyLocationsAsync(GetNearbyLocationsRequest request)
    {
        var queryString = $"?latitude={request.Latitude}&longitude={request.Longitude}&radiusKm={request.RadiusKm}";
        if (request.Type.HasValue)
            queryString += $"&type={request.Type}";
        if (request.OnlyFree.HasValue)
            queryString += $"&onlyFree={request.OnlyFree}";

        var response = await _httpClient.GetAsync($"api/locations/nearby{queryString}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<GetNearbyLocationsResponse>() ?? new();
    }

    public async Task<CreateLocationResponse> CreateLocationAsync(CreateLocationRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/locations", request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CreateLocationResponse>() ?? new();
    }
}