using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Models.DTOs;

public record ReservationDto(string? Id, string? restaurantName , string? userName, string? phoneNumber, string? email, string? dateTime, int numOfPeople, int lenght, string? comment);
public record CreateReservationDto(string? restaurantId, string? dateTime, int numOfPeople, int lenght, string? comment);