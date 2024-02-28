using Microsoft.EntityFrameworkCore;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;
using TemalabBackEnd.Models.EntityFrameworkModel.Tables;

namespace TemalabBackEnd.Models.EntityFrameworkModel.DbModels
{
    public class ModelContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<LikedRestaurant> LikedRestaurants { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
