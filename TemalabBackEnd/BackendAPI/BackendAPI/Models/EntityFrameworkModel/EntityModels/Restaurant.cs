﻿using BackendAPI.Models.EntityFrameworkModel.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Étterem típust reprezentáló osztály
    public class Restaurant : IEntityModelBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(Menu))]
        public int MenuId { get; set; }
        public Menu Menu { get; set; } //Navigation property
        [Column]
        public string Name { get; set; }
        [Column]
        public string Description { get; set; }
        [Column]
        public string Label { get; set; }
        [Column]
        public string City { get; set; }
        [Column]
        public string Street { get; set; }
        [Column]
        public int HouseNumber { get; set; }
        [Column]
        public int PostCode { get; set; }
        [Column]
        public string PhoneNumber { get; set; }
        [Column]
        public string OpeningHours { get; set; }
        public Restaurant() { }
        public Restaurant(Menu menu, string name, string description, string label, string city, string street, int houseNumber, int postCode, string phoneNumber, string openingHours)
        {
            Menu = menu;
            MenuId = menu.Id;
            Name = name;
            Description = description;
            Label = label;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            PostCode = postCode;
            PhoneNumber = phoneNumber;
            OpeningHours = openingHours;
        }
    }
}