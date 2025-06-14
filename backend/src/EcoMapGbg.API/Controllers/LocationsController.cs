using Microsoft.AspNetCore.Mvc;
using EcoMapGbg.Application.UseCases.GetNearbyLocations;
using EcoMapGbg.Application.UseCases.CreateLocation;
using EcoMapGbg.Domain.Exceptions;

namespace EcoMapGbg.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class LocationsController : ControllerBase
{
    private readonly GetNearbyLocationsUseCase _getNearbyUseCase;
    private readonly CreateLocationUseCase _createLocationUseCase;

    public LocationsController(
        GetNearbyLocationsUseCase getNearbyUseCase,
        CreateLocationUseCase createLocationUseCase)
    {
        _getNearbyUseCase = getNearbyUseCase;
        _createLocationUseCase = createLocationUseCase;
    }

    /// <summary>
    /// Get all active locations
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<LocationSummaryDto>), 200)]
    public async Task<ActionResult<List<LocationSummaryDto>>> GetAll()
    {
        // For now, return all locations in Göteborg area
        var request = new GetNearbyLocationsRequest
        {
            Latitude = 57.7089,
            Longitude = 11.9746,
            RadiusKm = 50 // Large radius to get all locations
        };

        var response = await _getNearbyUseCase.ExecuteAsync(request);
        return Ok(response.Locations);
    }

    /// <summary>
    /// Get locations near specified coordinates
    /// </summary>
    [HttpGet("nearby")]
    [ProducesResponseType(typeof(GetNearbyLocationsResponse), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<GetNearbyLocationsResponse>> GetNearby(
        [FromQuery] GetNearbyLocationsRequest request)
    {
        try
        {
            var response = await _getNearbyUseCase.ExecuteAsync(request);
            return Ok(response);
        }
        catch (DomainException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>
    /// Create a new eco location
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(CreateLocationResponse), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<CreateLocationResponse>> CreateLocation(
        [FromBody] CreateLocationRequest request)
    {
        try
        {
            var response = await _createLocationUseCase.ExecuteAsync(request);
            return CreatedAtAction(
                nameof(GetById),
                new { id = response.LocationId },
                response);
        }
        catch (DomainException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>
    /// Get location by ID
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(LocationDetailsResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<LocationDetailsResponse>> GetById(string id)
    {
        try
        {
            // Implement GetLocationDetailsUseCase
            return Ok(new { message = "Not implemented yet" });
        }
        catch (LocationNotFoundException)
        {
            return NotFound(new { error = "Location not found" });
        }
    }

    /// <summary>
    /// Health check endpoint
    /// </summary>
    [HttpGet("health")]
    public IActionResult Health()
    {
        return Ok(new {
            status = "healthy",
            timestamp = DateTime.UtcNow,
            service = "EcoMapGBG API"
        });
    }
}