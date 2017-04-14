using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsInfoWeb.Models
{
    public class Car:Vehicle
    {
        private string Fuel { get; set; }
        private string Type { get; set; }

        public Car(string brand, string model, string fuel, string type, decimal price)
        {
            //this.Id = Guid.NewGuid();
            this.Brand = brand;
            this.Model = model;
            this.Fuel = fuel;
            this.Type = type;
            this.Price = price;
        }
        
    }
    
}
