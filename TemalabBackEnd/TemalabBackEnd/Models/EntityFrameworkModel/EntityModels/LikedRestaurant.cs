namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Kedvelt Étterem típust reprezentáló osztály
    public class LikedRestaurant
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public Restaurant RestaurantId { get; set; }
    
        public LikedRestaurant(int id, User userid, Restaurant restaurantid)
        {
            Id = id;
            UserId = userid;
            RestaurantId = restaurantid;
        }
    }
}
