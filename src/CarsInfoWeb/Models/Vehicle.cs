using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CarsInfoWeb.Models
{
    public enum Color {White,Silver,Black,Grey,Blue,Red,Brown,Green,Other}
    public abstract class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public Color Color { get; set; }
        public string Picture { get; set; }
    }
}
