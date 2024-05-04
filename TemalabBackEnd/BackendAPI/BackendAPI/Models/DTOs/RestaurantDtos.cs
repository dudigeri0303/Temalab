namespace BackendAPI.Models.DTOs;

public record RestaurantDataDto(string? Id, string Name, string Description, string Label, string Location);
public record CreateRestaurantDto(string? Name, string? PostCode, string? City, 
    string? Street, string? HouseNumber, string? PhoneNumber, string? Description, string? Label);