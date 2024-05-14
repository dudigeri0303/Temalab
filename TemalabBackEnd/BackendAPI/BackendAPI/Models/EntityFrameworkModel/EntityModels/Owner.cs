using BackendAPI.Models.EntityFrameworkModel.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Tulajdonos típust reprezentáló osztály
    public class Owner : IEntityModelBase<Owner>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; } //Navigation property
        [ForeignKey(nameof(Restaurant))]
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } //Navigation property
        public Owner() { }
        public Owner(User user, Restaurant restaurant)
        {
            User = user;
            UserId = user.Id;
            Restaurant = restaurant;
            RestaurantId = restaurant.Id;
        }
    }
}
