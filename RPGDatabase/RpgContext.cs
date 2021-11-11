﻿using System;
using Microsoft.EntityFrameworkCore;
using RPGDatabase.Models.Character;


namespace RPGDatabase
{
    public class RpgContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectString = "server=localhost;port=3308;database=rpg_enigma;user=matheo;password=matheopass;";
            optionsBuilder.UseMySql(connectString, ServerVersion.AutoDetect(connectString));
        }

        public DbSet<Hero> HeroSet { get; set; }
    }
}