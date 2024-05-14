using BackendAPI.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Models.DTOs;

public record RestaurantDataDto(string? Id, string Name, string Description, string Label, string Location, List<OpeningHourDto>? openingHours);
public record CreateRestaurantDto(string? Name, string? PostCode, string? City, 
    string? Street, string? HouseNumber, string? PhoneNumber, string? Description, string? Label, List<OpeningHourDto>? openingHours);
public record UpdateRestaurantDto(string? Name, string? PostCode, string? City,
    string? Street, string? HouseNumber, string? PhoneNumber, string? Description, string? Label);