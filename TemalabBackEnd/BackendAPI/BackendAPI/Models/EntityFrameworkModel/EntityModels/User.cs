using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Felhasználó típust reprezentáló osztály
    public class User : IdentityUser
    {
        public string? UserRole { get; set; }

        public User() : base() 
        {
            this.UserRole = "user";
        }
        
    }
}
