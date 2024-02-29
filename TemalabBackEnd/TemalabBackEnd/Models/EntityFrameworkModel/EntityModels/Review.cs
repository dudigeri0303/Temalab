namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Értékelés típust reprezentáló osztály
    public class Review
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public Restaurant RestaurantId { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }

        public Review(int id, User userid, Restaurant restaurantid, int rating, string description) 
        {
            Id = id;
            UserId = userid;
            RestaurantId = restaurantid;
            Rating = rating;
            Description = description;
        }
    }
}
