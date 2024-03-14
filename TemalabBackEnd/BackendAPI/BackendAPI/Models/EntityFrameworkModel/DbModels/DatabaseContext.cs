﻿using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace TemalabBackEnd.Models.EntityFrameworkModel.DbModels
{
    //EntityModel atabázis kontextus
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<LikedRestaurant> LikedRestaurants { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }

        public Dictionary<Type, object> EntityTables { get; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            EntityTables = new Dictionary<Type, object>() 
            {
                { typeof(User), Users},
                { typeof(Admin), Admins},
                { typeof(Owner), Owners},
                { typeof(Restaurant), Restaurants},
                { typeof(Table), Tables},
                { typeof(LikedRestaurant), LikedRestaurants},
                { typeof(Reservation), Reservations},
                { typeof(Review), Reviews},
                { typeof(Menu), Menus},
                { typeof(Category), Categories},
                { typeof(Food), Foods}
            };
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Owner>().ToTable("Owners");
            modelBuilder.Entity<Restaurant>().ToTable("Restaurants");
            modelBuilder.Entity<Table>().ToTable("Tables");
            modelBuilder.Entity<LikedRestaurant>().ToTable("LikedRestaurants");
            modelBuilder.Entity<Reservation>().ToTable("Reservations");
            modelBuilder.Entity<Review>().ToTable("Reviews");
            modelBuilder.Entity<Menu>().ToTable("Menus");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Food>().ToTable("Foods");
        }

        public DbSet<T> GetDbSet<T>() where T : class
        {
            foreach (var kvp in this.EntityTables)
            {
                if (typeof(DbSet<T>).IsAssignableFrom(kvp.Value.GetType()))
                {
                    return (DbSet<T>)kvp.Value;
                }
            }
            return null;
        }

    }
}

