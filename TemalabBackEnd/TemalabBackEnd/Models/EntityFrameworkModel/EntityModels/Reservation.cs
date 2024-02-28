namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Foglalás típust reprezentáló osztály
    public class Reservation
    {
        public int Id { get; set; }
        public Table TableId { get; set; }
        public User ReserverId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Reservation(User reserverid, Table tableid) 
        {
            ReserverId = reserverid;
            TableId = tableid;
        }
    }
}
