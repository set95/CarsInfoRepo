using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CarsInfoWeb.Models
{
    public abstract class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        //public int Year { get; set; }
        //public int Mileage { get; set; }
        //public decimal Price { get; set; }
        //public string Color { get; set; }
    }
}
