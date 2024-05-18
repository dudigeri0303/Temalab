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
        public string Id { get; set; }
        [ForeignKey(nameof(Menu))]
        public string MenuId { get; set; }
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
        public int NumOfFreeSeats { get; set; }
        public Restaurant() { }
        public Restaurant(string name, string description, string label, string city, string street, int houseNumber, int postCode, string phoneNumber)
        {
            Menu = new Menu();
            MenuId = Menu.Id;
            Name = name;
            Description = description;
            Label = label;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            PostCode = postCode;
            PhoneNumber = phoneNumber;
            NumOfFreeSeats = 0;
        }
    }
}
