namespace BackendAPI.Models.DTOs;

public record UserRegisterDto(string? UserName, string? Email, string? PhoneNumber, string? Password, string? PasswordAgain, string? UserRole);
public record struct UserLoginDto
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? UserRole { get; set; }

};


public record UserDatasDto(string? Name, string? PhoneNumber, string? Email);