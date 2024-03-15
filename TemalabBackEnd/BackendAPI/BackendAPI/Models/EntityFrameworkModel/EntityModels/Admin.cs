using BackendAPI.Models.EntityFrameworkModel.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Admin típust reprezentáló osztály
    public class Admin : IEntityModelBase<Admin>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; } //Navigation property
        [Column]
        public string Token { get; set; }
        public Admin() { }
        public Admin(User user, string token) 
        {
            User = user;
            UserId = user.Id;
            Token = token;
        }

        public void updateEntity(Admin entity)
        {
            if (entity.Token != "string" && entity.Token.Trim() != "")
            {
                this.Token = entity.Token;
            }
        }
    }
}
