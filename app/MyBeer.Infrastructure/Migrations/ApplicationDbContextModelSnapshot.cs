﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBeer.Infrastructure.Data;

#nullable disable

namespace MyBeer.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("MyBeer.Domain.Entities.Beer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("MyBeer.Domain.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("MyBeer.Infrastructure.Models.BeerIngredient", b =>
                {
                    b.Property<Guid>("BeerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("TEXT");

                    b.HasKey("BeerId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("BeerIngredients");
                });

            modelBuilder.Entity("MyBeer.Infrastructure.Models.BeerIngredient", b =>
                {
                    b.HasOne("MyBeer.Domain.Entities.Beer", "Beer")
                        .WithMany()
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBeer.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");

                    b.Navigation("Ingredient");
                });
#pragma warning restore 612, 618
        }
    }
}
