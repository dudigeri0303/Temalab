using System.ComponentModel.DataAnnotations;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        
        public Menu() { }
        public Menu(int id)
        {
            Id = id;
        } 
    }
}
