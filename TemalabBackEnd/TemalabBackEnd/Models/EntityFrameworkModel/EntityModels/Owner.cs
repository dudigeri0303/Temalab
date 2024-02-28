using TemalabBackEnd.Models.EntityFrameworkModel.Tables;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    public class Owner
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public Restaurant RestaurantId { get; set; }
        public Owner(User userid, Restaurant restaurantid)
        {
            UserId = userid;
            RestaurantId = restaurantid;
        }
    }
}
