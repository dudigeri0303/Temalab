using BackendAPI.Models.EntityFrameworkModel.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    public class Food : IEntityModelBase<Food>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public Food(){ }

        public Food(Category category, string name, string description, int price)
        {
            Category = category;
            CategoryId = Category.Id;
            Name = name;
            Description = description;
            Price = price;
        }

        public void updateEntity(Food entity)
        {
            if (entity.Name != "string" && entity.Description.Trim() != "")
            {
                this.Name = entity.Name;
            }
            if (entity.Description != "string" && entity.Description.Trim() != "")
            {
                this.Description = entity.Description;
            }
            if (entity.Price != 0)
            {
                this.Price = entity.Price;
            }
        }
    
    }
}
