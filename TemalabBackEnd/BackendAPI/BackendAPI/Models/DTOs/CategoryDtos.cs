namespace BackendAPI.Models.DTOs;

public record CreateCategoryDto(string Name);
public record CategoryDto(string Id, string CategoryName);