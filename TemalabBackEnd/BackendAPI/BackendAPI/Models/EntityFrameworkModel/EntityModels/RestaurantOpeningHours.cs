using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;
using BackendAPI.Models.EntityFrameworkModel.Common;

namespace BackendAPI.Models.EntityFrameworkModel.EntityModels
{
    public class RestaurantOpeningHours : IEntityModelBase<RestaurantOpeningHours>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public Restaurant? Restaurant { get; set; }
        [ForeignKey(nameof(Restaurant))]
        public string? RestaurantId { get; set; }
        [Column]
        public string? DayName { get; set; }
        [Column]
        public string? OpeningHour { get; set; }

        public RestaurantOpeningHours() 
        {
        
        }
        public RestaurantOpeningHours(Restaurant restaurant, string dayName, string openingHour)
        {
            Restaurant = restaurant;
            RestaurantId = restaurant.Id;
            DayName = dayName;
            OpeningHour = openingHour;
        }
    }
}
