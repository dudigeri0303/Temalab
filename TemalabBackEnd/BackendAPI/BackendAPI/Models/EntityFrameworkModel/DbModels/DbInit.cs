using Microsoft.AspNetCore.Identity;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace TemalabBackEnd.Models.EntityFrameworkModel.DbModels
{
    //Adatbázist statikus inicializáló metódust tartalmazó osztály
    public class DbInit
    {
        public static async void Init(DatabaseContext databaseContext, UserManager<User> userManager) 
        {
            databaseContext.Database.EnsureCreated();

            //Az a sok sor elvileg így kiváltható. Ehhez viszont létre kell hozni a szótárat a DbContext-ben a táblákkal
            //Ahogy nézem a kulcsok nem növekednek így. Ezt le kéne még ellenőrizni.
            foreach (var kvp in databaseContext.EntityTables)
            {
                Type entityType = kvp.Key;
                var dbSet = (IQueryable<object>)kvp.Value;
                var existingEntities = dbSet.ToList();
                databaseContext.RemoveRange(existingEntities);
                databaseContext.SaveChanges();
            }

            //USERS
            var users = new User[] 
            {
                new User 
                { 
                    UserName = "Jozsi",
                    Email = "jozsi@gmail.com",
                    PhoneNumber = "1234567890",
                    UserRole = "user"
                },
                new User
                {
                    UserName = "Anna",
                    Email = "anna@gmail.com",
                    PhoneNumber = "1234523444",
                    UserRole = "user"
                },
                new User
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    PhoneNumber = "5783267890",
                    UserRole = "admin"
                },
                new User
                {
                    UserName = "boss",
                    Email = "hugo.boss@gmail.com",
                    PhoneNumber = "3238927890",
                    UserRole = "owner"
                }
            }; 
            
            foreach(var user in users) 
            {
                await userManager.CreateAsync(user, "A2dq3s00?34");
            }
            
            /*foreach (User user in users) 
            {
                databaseContext.Users.Add(user);
            }*/
         
            //databaseContext.SaveChanges();
        
            //ADMINS
            var admins = new Admin[]
            {
                new Admin(users[2],"ahfjkhaskj")
            };
            foreach (Admin admin in admins)
            {
                databaseContext.Admins.Add(admin);
            }
            databaseContext.SaveChanges();

            //MENUS
            var menus = new Menu[]
            {
                new Menu()
            };
            foreach (Menu menu in menus)
            {
                databaseContext.Menus.Add(menu);
            }
            databaseContext.SaveChanges();

            //CATEGORIES
            var categories = new Category[]
            {
                new Category(menus[0],"leves-torta")
            };
            foreach (Category category in categories)
            {
                databaseContext.Categories.Add(category);
            }
            databaseContext.SaveChanges();

            //FOODS
            var foods = new Food[]
            {
                new Food(categories[0],"fank","fini es mini",6969),
                new Food(categories[0],"cica","meow",1244),
                new Food(categories[0],"kuta","vau",542)
            };
            foreach (Food food in foods)
            {
                databaseContext.Foods.Add(food);
            }
            databaseContext.SaveChanges();

            //REASTAURANTS
            var restaurants = new Restaurant[]
            {
                new Restaurant(menus[0],"Etterem","lorem ipsum","finom","Budapest","Tudosok krt",2,1117,"553345563","0-24"),
                new Restaurant(menus[0],"Etterem2","lorem ipsum dingdong","nagyonfinom","Bukarest","Blaha",69,1083,"344453422","12-24")
            };
            foreach (Restaurant restaurant in restaurants)
            {
                databaseContext.Restaurants.Add(restaurant);
            }
            databaseContext.SaveChanges();

            //OWNERS
            var owners = new Owner[]
            {
                new Owner(users[3],restaurants[0]),
                new Owner(users[3],restaurants[1])
            };
            foreach (Owner owner in owners)
            {
                databaseContext.Owners.Add(owner);
            }
            databaseContext.SaveChanges();

            //TABLES
            var tables = new Table[]
            {
                new Table(restaurants[0],4),
                new Table(restaurants[0],6),
                new Table(restaurants[0],8)
            };
            foreach (Table table in tables)
            {
                databaseContext.Tables.Add(table);
            }
            databaseContext.SaveChanges();

            //LIKED RESTAURANTS
            var likedrestaurants = new LikedRestaurant[]
            {
                new LikedRestaurant(users[0],restaurants[0]),
                new LikedRestaurant(users[1],restaurants[0]),
                new LikedRestaurant(users[2],restaurants[0])
            };
            foreach (LikedRestaurant likedrestaurant in likedrestaurants)
            {
                databaseContext.LikedRestaurants.Add(likedrestaurant);
            }
            databaseContext.SaveChanges();

            //REVIEWS
            var reviews = new Review[]
            {
                new Review(users[0],restaurants[0],4,"fincsa es mincsa"),
                new Review(users[1],restaurants[0],4,"fincsa es mincsa"),
                new Review(users[2],restaurants[0],4,"fincsa es mincsa")
            };
            foreach (Review review in reviews)
            {
                databaseContext.Reviews.Add(review);
            }
            databaseContext.SaveChanges();

            //RESERVATIONS
            var reservations = new Reservation[]
            {
                new Reservation(users[0],tables[0]),
                new Reservation(users[1],tables[1]),
                new Reservation(users[2],tables[2])
            };
            foreach (Reservation reservation in reservations)
            {
                databaseContext.Reservations.Add(reservation);
            }
            databaseContext.SaveChanges();
        }
    }
}
