using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;



namespace CarsInfoWeb.Models
{
    public enum Color {White,Silver,Black,Grey,Blue,Red,Brown,Green,Other}
    public abstract class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        [Display(Name = "Price(Euro)")]
        public decimal Price { get; set; }
        public int Year { get; set; }
        [Display(Name = "Mileage(km)")]
        public int Mileage { get; set; }
        public Color Color { get; set; }
        [Display(Name = "Pricture of car")]
        public string Picture { get; set; }
        /*[ForeignKey("UserId")]
        public int UserId { get; set; }
        */
    }
}
