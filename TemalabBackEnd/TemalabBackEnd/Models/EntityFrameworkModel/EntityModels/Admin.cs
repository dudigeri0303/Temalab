namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Admin típust reprezentáló osztály
    public class Admin
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public string Token { get; set; }

        public Admin(int id, User userid, string token) 
        {
            Id = id;
            UserId = userid;
            Token = token;
        }
    }
}
