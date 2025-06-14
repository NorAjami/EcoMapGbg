using MongoDB.Driver;
using EcoMapGbg.Infrastructure.Data;
using EcoMapGbg.Application.Common.Interfaces;
using EcoMapGbg.Application.UseCases.GetNearbyLocations;
using EcoMapGbg.Application.UseCases.CreateLocation;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() {
        Title = "EcoMapGBG API",
        Version = "v1",
        Description = "API for eco-friendly locations in Göteborg"
    });
});

// CORS for frontend
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5001", "https://localhost:7001") // Frontend URLs
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// MongoDB
var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDB")
    ?? "mongodb://localhost:27017";

builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(mongoConnectionString));

builder.Services.AddScoped<IMongoDatabase>(sp =>
    sp.GetRequiredService<IMongoClient>().GetDatabase("ecomapgbg"));

// Repositories
builder.Services.AddScoped<ILocationRepository, MongoLocationRepository>();

// Use Cases
builder.Services.AddScoped<GetNearbyLocationsUseCase>();
builder.Services.AddScoped<CreateLocationUseCase>();

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcoMapGBG API v1");
        c.RoutePrefix = string.Empty; // Serve Swagger at root
    });
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();