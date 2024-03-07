﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Foglalás típust reprezentáló osztály
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Table))]
        public int TableId { get; set; }
        public Table Table { get; set; } //Navigation property
        [ForeignKey(nameof(Reserver))]
        public int ReserverId { get; set; }
        public User Reserver { get; set; } //Navigation property
        [Column]
        public DateTime StartDate { get; set; }
        [Column]
        public DateTime EndDate { get; set; }
        
        public Reservation() { }
        public Reservation(int id, User reserver, Table table) 
        {
            Id = id;
            Reserver = reserver;
            ReserverId = reserver.Id;
            Table = table;
            TableId = table.Id;
        }
    }
}
