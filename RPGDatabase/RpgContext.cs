using System;
using Microsoft.EntityFrameworkCore;
using RPGDatabase.Models.Character;
using RPGDatabase.Models.GamePart;
using RPGDatabase.Models.Item;
using RPGDatabase.Models.ManyToMany;

namespace RPGDatabase
{
    /**
     * Classe RpgContext qui extend de DbContext
     * Permet de paramétrer la connexion à la BDD 
     * Puis de définir les fonctions d'accès et d'ajout à la BDD
     */
    public class RpgContext : DbContext
    {
        /**
         * CONFIGURATION CONNEXION SQL
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectString = "server=localhost;port=3308;database=rpg_enigma;user=matheo;password=matheopass;";
            optionsBuilder.UseMySql(connectString, ServerVersion.AutoDetect(connectString));
        }

        /**
         * ----------------------------------
         * REGLE DE RELATION ENTRE LES TABLES
         * ----------------------------------
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ONE TO ONE
            modelBuilder.Entity<Party>()
                .HasOne(p => p.Hero)
                .WithOne(h => h.Party)
                .HasForeignKey<Hero>(h => h.PartyId);

            modelBuilder.Entity<Party>()
                .HasOne(p => p.Story)
                .WithOne(s => s.Party)
                .HasForeignKey<LevelStory>(s => s.PartyId);

            // MANY TO MANY
            modelBuilder.Entity<HeroWeapon>()
                .HasOne(h => h.Hero)
                .WithMany(hw => hw.HeroWeapons)
                .HasForeignKey(hi => hi.HeroId);

            modelBuilder.Entity<HeroWeapon>()
                .HasOne(w => w.Weapon)
                .WithMany(hw => hw.HeroWeapons)
                .HasForeignKey(wi => wi.WeaponId);

            modelBuilder.Entity<HeroConsomable>()
                .HasOne(h => h.Hero)
                .WithMany(hc => hc.HeroConsomables)
                .HasForeignKey(hi => hi.HeroId);

            modelBuilder.Entity<HeroConsomable>()
                .HasOne(c => c.Consomable)
                .WithMany(hc => hc.HeroConsomables)
                .HasForeignKey(ci => ci.ConsomableId);

            modelBuilder.Entity<HeroEquipment>()
                .HasOne(h => h.Hero)
                .WithMany(he => he.HeroEquipments)
                .HasForeignKey(hi => hi.HeroId);

            modelBuilder.Entity<HeroEquipment>()
                .HasOne(e => e.Equipment)
                .WithMany(he => he.HeroEquipments)
                .HasForeignKey(ei => ei.EquipmentId);
        }

        /**
         * ----------------------------------
         * METHODES D'ACCES AUX TABLES BDD
         * ----------------------------------
         */
        public DbSet<Hero> HeroSet { get; set; }

        public DbSet<Monster> MonsterSet { get; set; }

        public DbSet<Party> PartySet { get; set; }

        public DbSet<Equipment> EquipmentSet { get; set; }

        public DbSet<Consomable> ConsomableSet { get; set; }

        public DbSet<Weapon> WeaponSet { get; set; }

        public DbSet<LevelStory> StorySet { get; set; }

        public DbSet<HeroWeapon> HeroWeapon { get; set; }

        public DbSet<HeroEquipment> HeroEquipment { get; set; }

        public DbSet<HeroConsomable> HeroConsomable { get; set; }
    }
}
