using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace TemalabBackEnd.Models.EntityFrameworkModel.DbModels
{
    //Adatbázist statikus inicializáló metódust tartalmazó osztály
    public class DbInit
    {
        public static void Init(DatabaseContext databaseContext) 
        {
            databaseContext.Database.EnsureCreated();
            
            var users = new User[] 
            {
                //User objektumok létrehozása
            
            };
            foreach (User user in users) 
            {
                databaseContext.Users.Add(user);
            }
            databaseContext.SaveChanges();

            //A user-hez hasonlóan az összes táblát így kell létrehozni
        }
    }
}
