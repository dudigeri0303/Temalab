using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Kedvelt Étterem típust reprezentáló osztály
    public class LikedRestaurant
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; } //Navigation preoperty
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } //Navigation property
        
        public LikedRestaurant() { }
        public LikedRestaurant(int id, User user, Restaurant restaurant)
        {
            Id = id;
            User = user;
            UserId = user.Id;
            Restaurant = restaurant;
            RestaurantId = restaurant.Id;
        }
    }
}
