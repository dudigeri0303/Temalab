namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Felhasználó típust reprezentáló osztály
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserRole { get; set; }

        public User(int id, string username, string password, string email, string phoneNumber, string userrole) 
        {
            Id = id;
            UserName = username;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber; 
            UserRole = userrole;
        }
    }
}
