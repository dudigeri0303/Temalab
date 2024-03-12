using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Asztal típust reprezentáló osztály
    public class Table
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } //Navigation property
        [Column]
        public int NumOfSeats { get; set; }
        [Column]
        public bool IsReserved { get; set; }
        
        public Table() { }
        public Table(int id, Restaurant restaurant, int numofseats)
        {
            Id = id;
            Restaurant = restaurant;
            RestaurantId = restaurant.Id;
            NumOfSeats = numofseats;
            IsReserved = false;
        }
    }
}
