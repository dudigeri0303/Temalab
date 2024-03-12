using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Felhasználó típust reprezentáló osztály
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Column]
        public string UserName { get; set; }
        [Column]
        public string Password { get; set; }
        [Column]
        public string Email { get; set; }
        [Column]
        public string PhoneNumber { get; set; }
        [Column]
        public string UserRole { get; set; }
        
        public User() { }
        public User(int id, string username, string password, string email, string phoneNumber, string userrole) 
        {
            Id = id;
            UserName = username;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber; 
            UserRole = userrole;
        }
    }
}
