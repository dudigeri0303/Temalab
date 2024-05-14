using BackendAPI.Models.EntityFrameworkModel.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    public class Category : IEntityModelBase<Category>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [ForeignKey(nameof(Menu))]
        public string MenuId { get; set; }
        public Menu Menu { get; set; } //Navigation property
        [Column]
        public string Name { get; set; }
        public Category() { }
        public Category(Menu menu ,string name) 
        {
            Menu = menu;
            MenuId = menu.Id;
            Name = name;
        }
    }
}
