﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPGDatabase;

namespace RPGDatabase.Migrations
{
    [DbContext(typeof(RpgContext))]
    partial class RpgContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("RPGDatabase.Models.Character.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<int>("Discretion")
                        .HasColumnType("int");

                    b.Property<int>("ExperienceLvl")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int>("Pv")
                        .HasColumnType("int");

                    b.Property<int>("PvMax")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HeroSet");
                });

            modelBuilder.Entity("RPGDatabase.Models.Character.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<int>("Discretion")
                        .HasColumnType("int");

                    b.Property<int>("ExperienceLvl")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int>("Pv")
                        .HasColumnType("int");

                    b.Property<int>("PvMax")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MonsterSet");
                });

            modelBuilder.Entity("RPGDatabase.Models.GamePart.LevelStory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IleType")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Pourcentage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StorySet");
                });

            modelBuilder.Entity("RPGDatabase.Models.GamePart.Party", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("HeroId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("StoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.HasIndex("StoryId");

                    b.ToTable("PartySet");
                });

            modelBuilder.Entity("RPGDatabase.Models.Item.ItemCtrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("HeroId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .HasColumnType("longtext");

                    b.Property<int?>("MonsterId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Pv")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.HasIndex("MonsterId");

                    b.ToTable("ItemCtrl");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ItemCtrl");
                });

            modelBuilder.Entity("RPGDatabase.Models.Item.Consomable", b =>
                {
                    b.HasBaseType("RPGDatabase.Models.Item.ItemCtrl");

                    b.HasDiscriminator().HasValue("Consomable");
                });

            modelBuilder.Entity("RPGDatabase.Models.Item.Equipment", b =>
                {
                    b.HasBaseType("RPGDatabase.Models.Item.ItemCtrl");

                    b.Property<int?>("HeroId1")
                        .HasColumnType("int");

                    b.HasIndex("HeroId1");

                    b.HasDiscriminator().HasValue("Equipment");
                });

            modelBuilder.Entity("RPGDatabase.Models.Item.Weapon", b =>
                {
                    b.HasBaseType("RPGDatabase.Models.Item.ItemCtrl");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Weapon");
                });

            modelBuilder.Entity("RPGDatabase.Models.GamePart.Party", b =>
                {
                    b.HasOne("RPGDatabase.Models.Character.Hero", "Hero")
                        .WithMany()
                        .HasForeignKey("HeroId");

                    b.HasOne("RPGDatabase.Models.GamePart.LevelStory", "Story")
                        .WithMany()
                        .HasForeignKey("StoryId");

                    b.Navigation("Hero");

                    b.Navigation("Story");
                });

            modelBuilder.Entity("RPGDatabase.Models.Item.ItemCtrl", b =>
                {
                    b.HasOne("RPGDatabase.Models.Character.Hero", null)
                        .WithMany("Loots")
                        .HasForeignKey("HeroId");

                    b.HasOne("RPGDatabase.Models.Character.Monster", null)
                        .WithMany("Loots")
                        .HasForeignKey("MonsterId");
                });

            modelBuilder.Entity("RPGDatabase.Models.Item.Equipment", b =>
                {
                    b.HasOne("RPGDatabase.Models.Character.Hero", null)
                        .WithMany("Equipments")
                        .HasForeignKey("HeroId1");
                });

            modelBuilder.Entity("RPGDatabase.Models.Character.Hero", b =>
                {
                    b.Navigation("Equipments");

                    b.Navigation("Loots");
                });

            modelBuilder.Entity("RPGDatabase.Models.Character.Monster", b =>
                {
                    b.Navigation("Loots");
                });
#pragma warning restore 612, 618
        }
    }
}
