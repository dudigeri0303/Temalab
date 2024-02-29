using System.ComponentModel;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    public class Category
    {
        public int Id { get; set; }
        public Menu MenuId { get; set; }
        public string Name { get; set; }
        public Category(int id, Menu menuid ,string name) 
        {
            Id = id;
            MenuId = menuid;
            Name = name;
        }
    }
}
