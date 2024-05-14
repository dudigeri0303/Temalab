using BackendAPI.Models.EntityFrameworkModel.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    public class Food : IEntityModelBase<Food>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public Category Category { get; set; } //Navigation property
        [ForeignKey(nameof(Category))]
        public string CategoryId { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string Description { get; set; }
        [Column]
        public int Price { get; set; }
        [Column]
        public byte[]? Image { get; set; }
        public Food(){ }

        public Food(Category category, string name, string description, int price)
        {
            Category = category;
            CategoryId = Category.Id;
            Name = name;
            Description = description;
            Price = price;
            Image = new byte[] { };
        }
        public Food(Category category, string name, string description, int price, byte[] image)
        {
            Category = category;
            CategoryId = Category.Id;
            Name = name;
            Description = description;
            Price = price;
            Image = image;
        }
        public void updateEntity(Food entity)
        {
            throw new NotImplementedException();
        }
    
    }
}
