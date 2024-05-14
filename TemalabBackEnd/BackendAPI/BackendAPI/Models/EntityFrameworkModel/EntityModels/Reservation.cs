using BackendAPI.Models.EntityFrameworkModel.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Foglalás típust reprezentáló osztály
    public class Reservation : IEntityModelBase<Reservation>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [ForeignKey(nameof(Table))]
        public string TableId { get; set; }
        public Table Table { get; set; } //Navigation property
        [ForeignKey(nameof(Reserver))]
        public string ReserverId { get; set; }
        public User Reserver { get; set; } //Navigation property
        [Column]
        public DateTime EndDate { get; set; }
        public Reservation() { }
        
        public Reservation(User reserver, Table table, DateTime date) 
        {
            Reserver = reserver;
            ReserverId = reserver.Id;
            Table = table;
            TableId = table.Id;
            EndDate = date;
        }
    }
}
