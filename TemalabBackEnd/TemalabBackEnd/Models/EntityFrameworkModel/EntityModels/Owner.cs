namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Tulajdonos típust reprezentáló osztály
    public class Owner
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public Restaurant RestaurantId { get; set; }
        public Owner(int id, User userid, Restaurant restaurantid)
        {
            Id = id;
            UserId = userid;
            RestaurantId = restaurantid;
        }
    }
}
