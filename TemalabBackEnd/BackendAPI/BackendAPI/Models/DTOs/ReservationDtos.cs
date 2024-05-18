namespace BackendAPI.Models.DTOs;

public record ReservationDto(string? Id, string? restaurantId, string? restaurantName ,string? dateTime, int numOfPeople);
public record CreateReservationDto(string? restaurantId, string? dateTime, int numOfPeople);