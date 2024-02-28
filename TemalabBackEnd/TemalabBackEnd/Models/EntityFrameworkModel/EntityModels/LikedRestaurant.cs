namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Kedvelt Étterem típust reprezentáló osztály
    public class LikedRestaurant
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public Restaurant RestaurantId { get; set; }
    
        public LikedRestaurant(User userid, Restaurant restaurantid)
        {
            UserId = userid;
            RestaurantId = restaurantid;
        }
    }
}
