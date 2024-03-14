using BackendAPI.Models.EntityFrameworkModel.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Értékelés típust reprezentáló osztály
    public class Review : IEntityModelBase<Review>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; } //Navigation preoperty
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } //Navigation preoperty
        [Column]
        public int Rating { get; set; }
        [Column]
        public string Description { get; set; }
        public Review() { }
        public Review(User user, Restaurant restaurant, int rating, string description) 
        {
            User = user;
            UserId = user.Id;
            Restaurant = restaurant;
            RestaurantId = restaurant.Id;
            Rating = rating;
            Description = description;
        }
        public void updateEntity(Review entity)
        {
            throw new NotImplementedException();
        }
    }
}
