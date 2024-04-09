using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Felhasználó típust reprezentáló osztály
    public class User : IdentityUser
    {
        public User() : base() 
        {
        }
    }
}
