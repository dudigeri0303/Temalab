using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace TemalabBackEnd.Models.EntityFrameworkModel.DbModels
{
    //Adatbázist statikus inicializáló metódust tartalmazó osztály
    public class DbInit
    {
        public static void Init(DatabaseContext databaseContext) 
        {
            databaseContext.Database.EnsureCreated();
            
            //USERS
            var users = new User[] 
            {
                new User(1,"Jozsi","asd","jozsi@gmail.com","111","customer"),
                new User(2,"Anna","asd","anna@gmail.com","222","customer"),
                new User(3,"admin","asd","admin@gmail.com","333","admin"),
                new User(4,"boss","asd","boss@gmail.com","444","owner")                
            };            
            foreach (User user in users) 
            {
                databaseContext.Users.Add(user);
            }
            databaseContext.SaveChanges();

            //ADMINS
            var admins = new Admin[]
            {
                new Admin(1,users[2],"ahfjkhaskj")
            };
            foreach (Admin admin in admins)
            {
                databaseContext.Admins.Add(admin);
            }
            databaseContext.SaveChanges();

            //MENUS
            var menus = new Menu[]
            {
                new Menu(1)
            };
            foreach (Menu menu in menus)
            {
                databaseContext.Menus.Add(menu);
            }
            databaseContext.SaveChanges();

            //CATEGORIES
            var categories = new Category[]
            {
                new Category(1,menus[0],"leves-torta")
            };
            foreach (Category category in categories)
            {
                databaseContext.Categories.Add(category);
            }
            databaseContext.SaveChanges();

            //FOODS
            var foods = new Food[]
            {
                new Food(1,categories[0],"fank","fini es mini",6969),
                new Food(2,categories[0],"cica","meow",1244),
                new Food(3,categories[0],"kuta","vau",542)
            };
            foreach (Food food in foods)
            {
                databaseContext.Foods.Add(food);
            }
            databaseContext.SaveChanges();

            //REASTAURANTS
            var restaurants = new Restaurant[]
            {
                new Restaurant(1,menus[0],"Etterem","lorem ipsum","finom","Budapest","Tudosok krt",2,1117,"553345563","0-24")
            };
            foreach (Restaurant restaurant in restaurants)
            {
                databaseContext.Restaurants.Add(restaurant);
            }
            databaseContext.SaveChanges();

            //OWNERS
            var owners = new Owner[]
            {
                new Owner(1,users[3],restaurants[0])
            };
            foreach (Owner owner in owners)
            {
                databaseContext.Owners.Add(owner);
            }
            databaseContext.SaveChanges();

            //TABLES
            var tables = new Table[]
            {
                new Table(1,restaurants[0],4),
                new Table(2,restaurants[0],6),
                new Table(3,restaurants[0],8)
            };
            foreach (Table table in tables)
            {
                databaseContext.Tables.Add(table);
            }
            databaseContext.SaveChanges();

            //LIKED RESTAURANTS
            var likedrestaurants = new LikedRestaurant[]
            {
                new LikedRestaurant(1,users[0],restaurants[0]),
                new LikedRestaurant(2,users[1],restaurants[0]),
                new LikedRestaurant(3,users[2],restaurants[0])
            };
            foreach (LikedRestaurant likedrestaurant in likedrestaurants)
            {
                databaseContext.LikedRestaurants.Add(likedrestaurant);
            }
            databaseContext.SaveChanges();

            //REVIEWS
            var reviews = new Review[]
            {
                new Review(1,users[0],restaurants[0],4,"fincsa es mincsa"),
                new Review(2,users[1],restaurants[0],4,"fincsa es mincsa"),
                new Review(3,users[2],restaurants[0],4,"fincsa es mincsa")
            };
            foreach (Review review in reviews)
            {
                databaseContext.Reviews.Add(review);
            }
            databaseContext.SaveChanges();

            //RESERVATIONS
            var reservations = new Reservation[]
            {
                new Reservation(1,users[0],tables[0]),
                new Reservation(2,users[1],tables[1]),
                new Reservation(3,users[2],tables[2])
            };
            foreach (Reservation reservation in reservations)
            {
                databaseContext.Reservations.Add(reservation);
            }
            databaseContext.SaveChanges();


            //A user-hez hasonlóan az összes táblát így kell létrehozni
        }
    }
}
