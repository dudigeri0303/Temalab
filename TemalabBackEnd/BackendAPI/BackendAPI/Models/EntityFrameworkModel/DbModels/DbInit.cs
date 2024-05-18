using BackendAPI.Controllers.Common;
using BackendAPI.Models.EntityFrameworkModel.EntityModels;
using Microsoft.AspNetCore.Identity;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace TemalabBackEnd.Models.EntityFrameworkModel.DbModels
{
    //Adatbázist statikus inicializáló metódust tartalmazó osztály
    public class DbInit
    {
        public static async void Init(DatabaseContext databaseContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) 
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

            //Meglévő userek törlése a AspNetUsers táblábol
            var existingusers = userManager.Users.ToList();
            foreach (var user in existingusers)
            {
                await userManager.DeleteAsync(user);
            }

            var customerRole = new IdentityRole("Customer");
            var ownerRole = new IdentityRole("Owner");
            var adminRole = new IdentityRole("Admin");            
            await roleManager.CreateAsync(customerRole);
            await roleManager.CreateAsync(ownerRole);
            await roleManager.CreateAsync(adminRole);


            //USERS
            var users = new User[] 
            {
                new User 
                { 
                    UserName = "Jozsi",
                    Email = "jozsi@gmail.com",
                    PhoneNumber = "1234567890"
                },
                new User
                {
                    UserName = "Anna",
                    Email = "anna@gmail.com",
                    PhoneNumber = "1234523444"
                },
                new User
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    PhoneNumber = "5783267890"
                },
                new User
                {
                    UserName = "boss",
                    Email = "hugo.boss@gmail.com",
                    PhoneNumber = "3238927890"
                }
            }; 
            
            foreach(var user in users) 
            {
                await userManager.CreateAsync(user, "Asdfgh123?");
            }

            await userManager.AddToRoleAsync(users[0], "Customer");
            await userManager.AddToRoleAsync(users[1], "Customer");
            await userManager.AddToRoleAsync(users[2], "Admin");
            await userManager.AddToRoleAsync(users[3], "Owner");
            await userManager.AddToRoleAsync(users[3], "Customer");
            
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

            //REASTAURANTS
            var restaurants = new Restaurant[]
            {
                new Restaurant("Etterem","lorem ipsum","finom","Budapest","Tudosok krt",2,1117,"553345563"),
                new Restaurant("Etterem2","lorem ipsum dingdong","nagyonfinom","Bukarest","Blaha",69,1083,"344453422")
            };
            foreach (Restaurant restaurant in restaurants)
            {
                databaseContext.Restaurants.Add(restaurant);
            }
            databaseContext.SaveChanges();

            //OPENINGHOURS
            var openingHours = new RestaurantOpeningHours[]
            {
                new RestaurantOpeningHours(restaurants[0], "Hétfő", "10-20"),
                new RestaurantOpeningHours(restaurants[0], "Kedd", "10-20"),
                new RestaurantOpeningHours(restaurants[0], "Szerda", "10-20"),
                new RestaurantOpeningHours(restaurants[0], "Csütörtök", "10-20"),
                new RestaurantOpeningHours(restaurants[0], "Péntek", "10-20"),
                new RestaurantOpeningHours(restaurants[0], "Szombat", "10-20"),
                new RestaurantOpeningHours(restaurants[0], "Vasárnap", "10-20"),

                new RestaurantOpeningHours(restaurants[1], "Hétfő", "12-15"),
                new RestaurantOpeningHours(restaurants[1], "Kedd", "12-15"),
                new RestaurantOpeningHours(restaurants[1], "Szerda", "12-15"),
                new RestaurantOpeningHours(restaurants[1], "Csütörtök", "12-15"),
                new RestaurantOpeningHours(restaurants[1], "Péntek", "12-15"),
                new RestaurantOpeningHours(restaurants[1], "Szombat", "12-15"),
                new RestaurantOpeningHours(restaurants[1], "Vasárnap", "12-15"),
            };
            foreach (var oh in openingHours) 
            {
                databaseContext.RestaurantOpeningHours.Add(oh);
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
            restaurants[0].NumOfFreeSeats += tables[0].NumOfSeats;
            restaurants[0].NumOfFreeSeats += tables[1].NumOfSeats;
            restaurants[0].NumOfFreeSeats += tables[2].NumOfSeats;

            foreach (Table table in tables)
            {
                databaseContext.Tables.Add(table);
            }
            databaseContext.SaveChanges();

            //CATEGORIES
            var categories = new Category[]
            {
                new Category(restaurants[0].Menu,"előétel"),
                new Category(restaurants[0].Menu,"főétel"),
                new Category(restaurants[0].Menu,"desszert"),
                new Category(restaurants[1].Menu,"italok"),
                new Category(restaurants[1].Menu,"snacks")
            };
            foreach (Category category in categories)
            {
                databaseContext.Categories.Add(category);
            }
            databaseContext.SaveChanges();

            //FOODS
            var foods = new Food[]
            {
                new Food(categories[0],"piritós","roppanós",299, ImageToByteArrayConverter.PathToByteArray("bread-toast").Result),
                new Food(categories[0],"humus","friss",799, ImageToByteArrayConverter.PathToByteArray("humus-nahut").Result),
                new Food(categories[1],"túrós csusza","kemencés",2990, ImageToByteArrayConverter.PathToByteArray("turos-csusza").Result),
                new Food(categories[2],"tiramisu","krémes",1190, ImageToByteArrayConverter.PathToByteArray("tiramisu").Result),
                new Food(categories[3],"gin","igazi angol gin",1570, ImageToByteArrayConverter.PathToByteArray("marine_drygin").Result),
                new Food(categories[3],"fanta","cukormentes",850, ImageToByteArrayConverter.PathToByteArray("fanta-orange-zero").Result),
                new Food(categories[4],"földimogyoró","pörkölt, sós",550, ImageToByteArrayConverter.PathToByteArray("peanuts").Result)
            };
            foreach (Food food in foods)
            {
                databaseContext.Foods.Add(food);
            }
            databaseContext.SaveChanges();

            //LIKED RESTAURANTS
            var likedrestaurants = new LikedRestaurant[]
            {
                new LikedRestaurant(users[0],restaurants[0]),
                new LikedRestaurant(users[0],restaurants[1]),
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
                new Reservation(users[0],restaurants[0], DateTime.Now.ToString(), 4),
                new Reservation(users[0],restaurants[1], DateTime.Now.ToString(), 4),
                new Reservation(users[1],restaurants[1], DateTime.Now.ToString(), 4),
                new Reservation(users[0],restaurants[0], DateTime.Now.ToString(), 4)
            };
            foreach (Reservation reservation in reservations)
            {
                databaseContext.Reservations.Add(reservation);
            }
            databaseContext.SaveChanges();            
        }
    }
}
