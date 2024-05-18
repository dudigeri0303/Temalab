using BackendAPI.Models.EntityFrameworkModel.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Globalization;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Foglalás típust reprezentáló osztály
    public class Reservation : IEntityModelBase<Reservation>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [ForeignKey(nameof(Table))]
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } //Navigation property
        [ForeignKey(nameof(Reserver))]
        public string ReserverId { get; set; }
        public User Reserver { get; set; } //Navigation property
        [Column]
        public string DateTime { get; set; }
        [Column]
        public int NumOfPeople {  get; set; }

        public Reservation() { }
        
        public Reservation(User reserver, Restaurant restaurant, string dateTime, int numOfPeople) 
        {
            Reserver = reserver;
            ReserverId = reserver.Id;
            Restaurant = restaurant;
            RestaurantId = restaurant.Id;
            DateTime = dateTime;
            NumOfPeople = numOfPeople;
        }
    }
}
