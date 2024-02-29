namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    public class Food
    {
        public int Id { get; set; }
        public Category CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Food(int id, Category categoryId, string name, string description, int price)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
