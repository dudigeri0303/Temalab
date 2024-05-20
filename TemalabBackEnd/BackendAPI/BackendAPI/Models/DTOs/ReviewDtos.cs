namespace BackendAPI.Models.DTOs;

public record ReviewDto(string Id, string UserName, int Rating, string Description);
public record CreateReviewDto(int Rating, string Description);