using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarsInfoWeb.Models
{
    public enum CarType {SUV,Truck,Sedan,Van,Coupe,Wagon,Cabrio,Hatchback}
    public enum Fuel {Diesel,Benzin,LPG, Methane,Hybrid, Electric }
    public class Car:Vehicle
    {
        public int CarId { get; set; }
        public Fuel Fuel { get; set; }
        public CarType Type { get; set; }
        public IEnumerable<Car> AddedCars { get; set; }

       /* public Car(string brand, string model, string fuel, string type, decimal price)
        {
            this.Brand = brand;
            this.Model = model;
            this.Fuel = fuel;
            this.Type = type;
            this.Price = price;
        }
        */
    }
    
}
