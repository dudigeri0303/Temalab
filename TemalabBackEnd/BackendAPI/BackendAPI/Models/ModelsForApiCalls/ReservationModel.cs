namespace BackendAPI.Models.ModelsForApiCalls
{
    public class ReservationModel
    {
        public string? Id {  get; set; }
        public string? RestaurantName { get; set; }
        public string? TableId { get; set; }
        public string? EndDate { get; set; }
    }
}
