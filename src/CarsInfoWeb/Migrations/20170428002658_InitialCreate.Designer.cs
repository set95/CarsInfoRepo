using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CarsInfoWeb.Models;

namespace CarsInfoWeb.Migrations
{
    [DbContext(typeof(CarsInfoContext))]
    [Migration("20170428002658_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarsInfoWeb.Models.CarsCatalog", b =>
                {
                    b.Property<int>("CatalogId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("CatalogId");

                    b.ToTable("CatalogCars");
                });

            modelBuilder.Entity("CarsInfoWeb.Models.Vehicle", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<int>("CatalogId");

                    b.Property<string>("Color");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Mileage");

                    b.Property<string>("Model");

                    b.Property<decimal>("Price");

                    b.Property<int>("Year");

                    b.HasKey("CarId");

                    b.HasIndex("CatalogId");

                    b.ToTable("Vehicle");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Vehicle");
                });

            modelBuilder.Entity("CarsInfoWeb.Models.Car", b =>
                {
                    b.HasBaseType("CarsInfoWeb.Models.Vehicle");

                    b.Property<string>("Fuel");

                    b.Property<string>("Type");

                    b.ToTable("Car");

                    b.HasDiscriminator().HasValue("Car");
                });

            modelBuilder.Entity("CarsInfoWeb.Models.MotorBike", b =>
                {
                    b.HasBaseType("CarsInfoWeb.Models.Vehicle");


                    b.ToTable("MotorBike");

                    b.HasDiscriminator().HasValue("MotorBike");
                });

            modelBuilder.Entity("CarsInfoWeb.Models.Vehicle", b =>
                {
                    b.HasOne("CarsInfoWeb.Models.CarsCatalog")
                        .WithMany("Cars")
                        .HasForeignKey("CatalogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
