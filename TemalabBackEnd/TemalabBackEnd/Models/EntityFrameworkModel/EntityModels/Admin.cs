﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemalabBackEnd.Models.EntityFrameworkModel.EntityModels
{
    //Admin típust reprezentáló osztály
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; } //Navigation property
        [Column]
        public string Token { get; set; }
        
        public Admin() { }
        public Admin(int id, User user, string token) 
        {
            Id = id;
            User = user;
            UserId = user.Id;
            Token = token;
        }
    }
}