﻿namespace BackendAPI.Models.ModelsForApiCalls
{
    public class RegisterModel
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? PasswordAgain { get; set; }
        public string? UserRole { get; set; }
    }
}