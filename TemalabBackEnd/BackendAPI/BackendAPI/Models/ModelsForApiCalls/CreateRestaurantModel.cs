namespace BackendAPI.Models.ModelsForApiCalls
{
    public class CreateRestaurantModel
    {
        public string? Name { get; set; }
        public string? PostCode { get; set; }
        public string? City {  get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Description { get; set; }
        //TODO normálistan megcsinálni frontenden, és aszerint itt javítani
        //, hogy ne beégetett értéke legyen
        public string? Label { get; set; }

    }
}
