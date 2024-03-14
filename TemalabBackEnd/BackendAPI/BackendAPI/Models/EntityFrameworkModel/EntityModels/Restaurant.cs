using BackendAPI.Models.EntityFrameworkModel.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Étterem típust reprezentáló osztály
    public class Restaurant : IEntityModelBase<Restaurant>
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
        public void updateEntity(Restaurant entity)
        {
            if (entity.Name != "string" && entity.Name.Trim() != "")
            {
                this.Name = entity.Name;
            }
            if (entity.Description != "string" && entity.Description.Trim() != "")
            {
                this.Description = entity.Description;
            }
            if (entity.Label != "string" && entity.Label.Trim() != "")
            {
                this.Label = entity.Label;
            }
            if (entity.City != "string" && entity.City.Trim() != "")
            {
                this.City = entity.City;
            }
            if (entity.Street != "string" && entity.Street.Trim() != "")
            {
                this.Street = entity.Street;
            }
            if (entity.HouseNumber != 0)
            {
                this.HouseNumber = entity.HouseNumber;
            }
            if (entity.PostCode != 0)
            {
                this.PostCode = entity.PostCode;
            }
            if (entity.PhoneNumber != "string" && entity.PhoneNumber.Trim() != "")
            {
                this.PhoneNumber = entity.PhoneNumber;
            }
            if (entity.OpeningHours != "string" && entity.OpeningHours.Trim() != "")
            {
                this.OpeningHours = entity.OpeningHours;
            }
        }
    }
}
