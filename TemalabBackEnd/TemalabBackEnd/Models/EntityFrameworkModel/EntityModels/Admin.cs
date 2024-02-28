using TemalabBackEnd.Models.EntityFrameworkModel.Tables;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    public class Admin
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public string Token { get; set; }

        public Admin(string token, User userid) 
        {
            Token = token;
            UserId = userid;
        }
    }
}
