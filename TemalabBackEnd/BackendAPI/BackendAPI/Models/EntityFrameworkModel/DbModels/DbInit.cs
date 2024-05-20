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
                    PhoneNumber = "+36703238475"
                },
                new User
                {
                    UserName = "Anna",
                    Email = "anna@gmail.com",
                    PhoneNumber = "+36208377564"
                },
                new User
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    PhoneNumber = "+36707744657"
                },
                new User
                {
                    UserName = "boss",
                    Email = "hugo.boss@gmail.com",
                    PhoneNumber = "+36306633535"
                },
                new User
                {
                    UserName = "fonok",
                    Email = "fonok@gmail.com",
                    PhoneNumber = "+36206622534"
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
            await userManager.AddToRoleAsync(users[4], "Owner");
        
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
                new Restaurant("Kocka Büfé","Gyors kaja vizsga előtt", "Kockáknak", "Budapest", "Tudosok körűt", 2, 1117, "+36703344231"),
                new Restaurant("CsülökFaloda","Házias csülök, ahogy a nagyi készíti!","Omlós hús, ropogós bőr","Keszthely","Kossuth Lajos utca", 46, 8360,"+36203345665"),
                new Restaurant("Antónió Pizza", "Igazi nápolyi pizza!", "Antonio Banderas Franchise", "Kistarcsa", "Szabadság út", 32, 2143, "+36706633600"),
                new Restaurant("Középkori Paraszt Étterem", "Parasztos ételek, kedves kiszolgálás", "Egyél Paraszt!!", "Ózd", "Kohász utca", 2, 3600, "+36204533524" )
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
                new RestaurantOpeningHours(restaurants[0], "Szombat", "zárva"),
                new RestaurantOpeningHours(restaurants[0], "Vasárnap", "zárva"),

                new RestaurantOpeningHours(restaurants[1], "Hétfő", "12-15"),
                new RestaurantOpeningHours(restaurants[1], "Kedd", "12-15"),
                new RestaurantOpeningHours(restaurants[1], "Szerda", "12-15"),
                new RestaurantOpeningHours(restaurants[1], "Csütörtök", "12-15"),
                new RestaurantOpeningHours(restaurants[1], "Péntek", "12-15"),
                new RestaurantOpeningHours(restaurants[1], "Szombat", "12-22"),
                new RestaurantOpeningHours(restaurants[1], "Vasárnap", "12-22"),

                new RestaurantOpeningHours(restaurants[2], "Hétfő", "zárva"),
                new RestaurantOpeningHours(restaurants[2], "Kedd", "08-20"),
                new RestaurantOpeningHours(restaurants[2], "Szerda", "08-20"),
                new RestaurantOpeningHours(restaurants[2], "Csütörtök", "08-20"),
                new RestaurantOpeningHours(restaurants[2], "Péntek", "08-20"),
                new RestaurantOpeningHours(restaurants[2], "Szombat", "08-20"),
                new RestaurantOpeningHours(restaurants[2], "Vasárnap", "08-20"),

                new RestaurantOpeningHours(restaurants[3], "Hétfő", "12-21"),
                new RestaurantOpeningHours(restaurants[3], "Kedd", "12-21"),
                new RestaurantOpeningHours(restaurants[3], "Szerda", "12-21"),
                new RestaurantOpeningHours(restaurants[3], "Csütörtök", "12-21"),
                new RestaurantOpeningHours(restaurants[3], "Péntek", "12-21"),
                new RestaurantOpeningHours(restaurants[3], "Szombat", "10-23"),
                new RestaurantOpeningHours(restaurants[3], "Vasárnap", "10-23")
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
                new Owner(users[3],restaurants[1]),
                new Owner(users[4],restaurants[2]),
                new Owner(users[4],restaurants[3])
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
                new Table(restaurants[0],8),
                
                new Table(restaurants[1],4),
                new Table(restaurants[1],6),
                new Table(restaurants[1],8),

                new Table(restaurants[2],2),
                new Table(restaurants[2],4),
                new Table(restaurants[2],16),

                new Table(restaurants[3],8),
                new Table(restaurants[3],10),
                new Table(restaurants[3], 15)


            };
            
            restaurants[0].NumOfFreeSeats += tables[0].NumOfSeats;
            restaurants[0].NumOfFreeSeats += tables[1].NumOfSeats;
            restaurants[0].NumOfFreeSeats += tables[2].NumOfSeats;
           
            restaurants[1].NumOfFreeSeats += tables[3].NumOfSeats;
            restaurants[1].NumOfFreeSeats += tables[4].NumOfSeats;
            restaurants[1].NumOfFreeSeats += tables[5].NumOfSeats;

            restaurants[2].NumOfFreeSeats += tables[6].NumOfSeats;
            restaurants[2].NumOfFreeSeats += tables[7].NumOfSeats;
            restaurants[2].NumOfFreeSeats += tables[8].NumOfSeats;

            restaurants[3].NumOfFreeSeats += tables[9].NumOfSeats;
            restaurants[3].NumOfFreeSeats += tables[10].NumOfSeats;
            restaurants[3].NumOfFreeSeats += tables[11].NumOfSeats;

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
                new Category(restaurants[1].Menu,"snacks"),
                new Category(restaurants[1].Menu, "húsok"),

                new Category(restaurants[2].Menu, "pizzák"),

                new Category(restaurants[3].Menu, "egytálétel"),
                new Category(restaurants[3].Menu, "feltét")
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
                new Food(categories[4],"földimogyoró","pörkölt, sós",550, ImageToByteArrayConverter.PathToByteArray("peanuts").Result),
                new Food(categories[5], "csülök pékné módra", "omlós", 3625, ImageToByteArrayConverter.PathToByteArray("csulok").Result),

                new Food(categories[6], "Margharita", "paradicsomos, bazsalikomos", 4000, ImageToByteArrayConverter.PathToByteArray("margharita").Result),
                new Food(categories[6], "Szalámis", "Eredeti olasz pepperóni", 4855, ImageToByteArrayConverter.PathToByteArray("szalamis").Result),
                new Food(categories[6], "Olivás", "Egyenesen egy olasz olajfáról", 5400, ImageToByteArrayConverter.PathToByteArray("olivas").Result),

                new Food(categories[7], "Slambuc", "Az alföldi juháaszok kedvence", 3500, ImageToByteArrayConverter.PathToByteArray("slambuc").Result),
                new Food(categories[7], "Töltött káposzta", "Savanyú, szószos, ahogy azt kell", 2950, ImageToByteArrayConverter.PathToByteArray("toltottkaposzta").Result),
                new Food(categories[8], "Pörkölt", "Reggel még legelt", 4125, ImageToByteArrayConverter.PathToByteArray("porkolt").Result)
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
                new LikedRestaurant(users[1],restaurants[1]),

                new LikedRestaurant(users[1],restaurants[2]),
                
                new LikedRestaurant(users[0],restaurants[3]),
                new LikedRestaurant(users[1],restaurants[3]),
            };
            foreach (LikedRestaurant likedrestaurant in likedrestaurants)
            {
                databaseContext.LikedRestaurants.Add(likedrestaurant);
            }
            databaseContext.SaveChanges();

            //REVIEWS
            var reviews = new Review[]
            {
                new Review(users[0],restaurants[0],4,"Zh előtt a legjobb!!", users[0].UserName!),

                new Review(users[1],restaurants[1], 5, "Isteni csülök, jó hangulat, baráti árak!", users[1].UserName!),

                new Review(users[0],restaurants[2], 1, "Tészta paradicsomszósszal? Nemár! A gatyámat is ráköltöttem", users[0].UserName!),
                new Review(users[1],restaurants[2], 3, "Átlagos pizza. Drága és mégcsak nem is olasz", users[1].UserName!),

                new Review(users[0],restaurants[3], 5, "Ez a nekem való kaja!!!", users[0].UserName!),
                new Review(users[1],restaurants[3], 3, "Nem bírom annyira zsíros. De nem rossz.", users[1].UserName!)
            };
            foreach (Review review in reviews)
            {
                databaseContext.Reviews.Add(review);
            }
            databaseContext.SaveChanges();

            //RESERVATIONS
            var reservations = new Reservation[]
            {
                new Reservation(users[0],restaurants[0], DateTime.Now.ToString(), 1, 1, "Zh előőt gyorsba egy tiramiska"),

                new Reservation(users[0],restaurants[1], DateTime.Now.ToString(), 4, 3, "Családi banzáj"),
                new Reservation(users[1],restaurants[1], DateTime.Now.ToString(), 2, 2, "Meghitt vacsora"),

                new Reservation(users[1], restaurants[2], DateTime.Now.ToString(), 2, 1, "Adok még egy esélyt"),

                new Reservation(users[0], restaurants[3], DateTime.Now.ToString(), 2, 3, "Barátnőmet hozom kedvenc éttermembe")
            };

            restaurants[0].NumOfFreeSeats -= reservations[0].NumOfPeople;
            restaurants[1].NumOfFreeSeats -= reservations[1].NumOfPeople;
            restaurants[1].NumOfFreeSeats -= reservations[2].NumOfPeople;
            restaurants[2].NumOfFreeSeats -= reservations[3].NumOfPeople;
            restaurants[3].NumOfFreeSeats -= reservations[4].NumOfPeople;

            foreach (Reservation reservation in reservations)
            {
                databaseContext.Reservations.Add(reservation);
            }
            databaseContext.SaveChanges();            
        }
    }
}
