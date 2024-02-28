using TemalabBackEnd.Models.EntityFrameworkModel.Tables;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    public class Review
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public Restaurant RestaurantId { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }

        public Review(User userid, Restaurant restaurantid, string description) 
        {
            UserId = userid;
            RestaurantId = restaurantid;
            Description = description;
        }
    }
}
