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

            modelBuilder.Entity("RPGDatabase.Models.Character.CharacterStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<int>("Discretion")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CharacterStat");
                });

            modelBuilder.Entity("RPGDatabase.Models.Character.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ExperienceLvl")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("StatsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatsId");

                    b.ToTable("HeroSet");
                });

            modelBuilder.Entity("RPGDatabase.Models.Character.Hero", b =>
                {
                    b.HasOne("RPGDatabase.Models.Character.CharacterStat", "Stats")
                        .WithMany()
                        .HasForeignKey("StatsId");

                    b.Navigation("Stats");
                });
#pragma warning restore 612, 618
        }
    }
}
