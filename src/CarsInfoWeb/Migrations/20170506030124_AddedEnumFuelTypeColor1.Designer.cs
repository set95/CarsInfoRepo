using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CarsInfoWeb.Models;

namespace CarsInfoWeb.Migrations
{
    [DbContext(typeof(CarsInfoContext))]
    [Migration("20170506030124_AddedEnumFuelTypeColor1")]
    partial class AddedEnumFuelTypeColor1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarsInfoWeb.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Color");

                    b.Property<int>("Fuel");

                    b.Property<string>("Make");

                    b.Property<int>("Mileage");

                    b.Property<string>("Model");

                    b.Property<decimal>("Price");

                    b.Property<int>("Type");

                    b.Property<int>("Year");

                    b.HasKey("CarId");

                    b.ToTable("Cars");
                });
        }
    }
}
