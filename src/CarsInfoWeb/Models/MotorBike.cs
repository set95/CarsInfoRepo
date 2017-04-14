using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace CarsInfoWeb.Models
{
    public class MotorBike:Vehicle
    {
        private int CubicCapacity { get; set; }
        private string Type { get; set; }

        public MotorBike(string brand, string model, int capacity, string type,decimal price)
        {
            //this.Id = Guid.NewGuid();
            this.Brand = brand;
            this.Model = model;
            this.CubicCapacity = capacity;
            this.Type = type;
            this.Price = price;
        }
    }
}
