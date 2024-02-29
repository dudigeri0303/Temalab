namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Asztal típust reprezentáló osztály
    public class Table
    {
        public int Id { get; set; }
        public Restaurant RestaurantId { get; set; }
        public int NumOfSeats { get; set; }
        public bool IsReserved { get; set; }

        public Table(Restaurant restaurantId)
        {
            RestaurantId = restaurantId;
        }
    }
}
