﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Data;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Server.Entities.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserName = "john_doe"
                        },
                        new
                        {
                            Id = 2,
                            UserName = "jane_smith"
                        },
                        new
                        {
                            Id = 3,
                            UserName = "michael_brown"
                        },
                        new
                        {
                            Id = 4,
                            UserName = "emily_jones"
                        },
                        new
                        {
                            Id = 5,
                            UserName = "david_wilson"
                        },
                        new
                        {
                            Id = 6,
                            UserName = "sarah_davis"
                        },
                        new
                        {
                            Id = 7,
                            UserName = "chris_miller"
                        },
                        new
                        {
                            Id = 8,
                            UserName = "laura_garcia"
                        },
                        new
                        {
                            Id = 9,
                            UserName = "daniel_lee"
                        },
                        new
                        {
                            Id = 10,
                            UserName = "olivia_martin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}