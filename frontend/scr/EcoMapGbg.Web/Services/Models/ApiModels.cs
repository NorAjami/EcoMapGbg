namespace EcoMapGbg.Web.Models;

// DTOs that match the backend API exactly
public class LocationSummaryDto
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
    public string Address { get; set; } = "";
    public double DistanceKm { get; set; }
    public bool IsFree { get; set; }
    public bool IsOpenNow { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class GetNearbyLocationsRequest
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double RadiusKm { get; set; } = 5.0;
    public LocationType? Type { get; set; }
    public bool? OnlyFree { get; set; }
    public int? MaxResults { get; set; }
}

public class GetNearbyLocationsResponse
{
    public List<LocationSummaryDto> Locations { get; set; } = new();
    public int TotalFound { get; set; }
    public double SearchRadius { get; set; }
    public CoordinatesDto UserLocation { get; set; } = new();
}

public class CreateLocationRequest
{
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    public LocationType? Type { get; set; }
    public string Description { get; set; } = "";
    public bool IsFree { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class CreateLocationResponse
{
    public string LocationId { get; set; } = "";
    public string Message { get; set; } = "";
}

public class CoordinatesDto
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public enum LocationType
{
    SecondHand,
    FreeShop,
    RecyclingCenter,
    BikeWorkshop,
    ClothingSwap,
    SharingService,
    RepairCafe
}