namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    public class Restaurant
    {
        //Étterem típust reprezentáló osztály
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string OpeningHours { get; set; }

        public Restaurant(int id, string name, string description, string label, string city, string street, int houseNumber, int postCode, string phoneNumber, string openingHours)
        {
            Id = id;
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
