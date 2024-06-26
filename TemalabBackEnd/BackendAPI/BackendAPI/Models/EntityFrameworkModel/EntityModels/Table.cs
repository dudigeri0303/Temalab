﻿using BackendAPI.Models.EntityFrameworkModel.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Asztal típust reprezentáló osztály
    public class Table : IEntityModelBase<Table>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [ForeignKey(nameof(Restaurant))]
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } //Navigation property
        [Column]
        public int NumOfSeats { get; set; }
        [Column]
        public bool IsReserved { get; set; }
        public Table() { }
        public Table(Restaurant restaurant, int numofseats)
        {
            Restaurant = restaurant;
            RestaurantId = restaurant.Id;
            NumOfSeats = numofseats;
            IsReserved = false;
        }
    }
}
