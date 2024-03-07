using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public Category Category { get; set; } //Navigation property
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string Description { get; set; }
        [Column]
        public int Price { get; set; }
        
        public Food() { }
        public Food(int id, Category category, string name, string description, int price)
        {
            Id = id;
            Category = category;
            CategoryId = Category.Id;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
