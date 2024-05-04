namespace BackendAPI.Models.DTOs;



public record TableDto(string Id, int NumOfSeats, bool IsReserved);
public record CreateTableDto(int NumOfSeats);


/*
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [ForeignKey(nameof(Restaurant))]
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } //Navigation property
        [Column]
        public int NumOfSeats { get; set; }
        [Column]
        public bool IsReserved { get; set; }
 
 */