using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Menu))]
        public int MenuId { get; set; }
        public Menu Menu { get; set; } //Navigation property
        [Column]
        public string Name { get; set; }
        
        public Category() { }
        public Category(int id, Menu menu ,string name) 
        {
            Id = id;
            Menu = menu;
            MenuId = menu.Id;
            Name = name;
        }
    }
}
