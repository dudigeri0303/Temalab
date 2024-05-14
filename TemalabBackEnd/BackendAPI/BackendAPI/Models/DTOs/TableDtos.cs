namespace BackendAPI.Models.DTOs;



public record TableDto(string Id, int NumOfSeats, bool IsReserved);
public record CreateTableDto(int NumOfSeats);