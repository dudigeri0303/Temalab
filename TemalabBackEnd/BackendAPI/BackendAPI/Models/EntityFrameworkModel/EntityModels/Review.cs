﻿using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Értékelés típust reprezentáló osztály
    public class Review : IEntityModelBase<Review>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; } //Navigation preoperty
        [ForeignKey(nameof(Restaurant))]
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } //Navigation preoperty
        [Column]
        public int Rating { get; set; }
        [Column]
        public string Description { get; set; }
        [Column]
        public string UserName { get; set; }
        public Review() { }
        public Review(User user, Restaurant restaurant, int rating, string description, string userName) 
        {
            User = user;
            UserId = user.Id;
            Restaurant = restaurant;
            RestaurantId = restaurant.Id;
            Rating = rating;
            Description = description;
            UserName = userName;
        }
    }
}
