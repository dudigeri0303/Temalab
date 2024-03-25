using BackendAPI.Models.EntityFrameworkModel.Common;
using Isopoh.Cryptography.Argon2;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Felhasználó típust reprezentáló osztály
    public class User : IEntityModelBase<User>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public User(string username, string password, string email, string phoneNumber, string userrole) 
        {
            UserName = username;
            Password = Argon2.Hash(password);
            Email = email;
            PhoneNumber = phoneNumber; 
            UserRole = userrole;
        }
        public void updateEntity(User entity)
        {
            if (entity.UserName != "string" && entity.UserName.Trim() != "")
            {
                this.UserName = entity.UserName;
            }
            if (entity.Password != "string" && entity.Password.Trim() != "")
            {
                this.Password = entity.Password;
            }
            if (entity.Email != "string" && entity.Email.Trim() != "")
            {
                this.Email = entity.Email;
            }
            if (entity.PhoneNumber != "string" && entity.PhoneNumber.Trim() != "")
            {
                this.PhoneNumber = entity.PhoneNumber;
            }
        }
    }
}
