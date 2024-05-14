namespace BackendAPI.Models.DTOs;

public record FoodDto(string Id, string Name, string Description, int Price, byte[] Image);
public record CreateFoodDto(string Name, string Description, int Price);
public record ImageDto(IFormFile imageFile);