using System;
using Microsoft.EntityFrameworkCore;
using RPGDatabase.Models.Character;
using RPGDatabase.Models.GamePart;
using RPGDatabase.Models.Item;

namespace RPGDatabase
{
    /**
     * Classe RpgContext qui extend de DbContext
     * Permet de paramétrer la connexion à la BDD 
     * Puis de définir les fonctions d'accès et d'ajout à la BDD
     */
    public class RpgContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectString = "server=localhost;port=3308;database=rpg_enigma;user=matheo;password=matheopass;";
            optionsBuilder.UseMySql(connectString, ServerVersion.AutoDetect(connectString));
        }

        public DbSet<Hero> HeroSet { get; set; }

        public DbSet<Monster> MonsterSet { get; set; }

        public DbSet<Party> PartySet { get; set; }

        public DbSet<Equipment> EquipmentSet { get; set; }

        public DbSet<Consomable> ConsomableSet { get; set; }

        public DbSet<Weapon> WeaponSet { get; set; }
    }
}
