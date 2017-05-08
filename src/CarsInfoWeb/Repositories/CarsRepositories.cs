using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using CarsInfoWeb.Models;
using CarsInfoWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CarsInfoWeb.Repositories
{
    public class CarsRepositories : Controller
    {
        private readonly CarsInfoContext db;

        public CarsRepositories(CarsInfoContext context)
        {
            this.db = context;
        }

        public Car CreateCar(Car newCar)
        {
            db.Cars.Add(newCar);
            db.SaveChanges();
            return newCar;
        }

        public Car GetCar(int id)
        {
            Car car = db.Cars.FirstOrDefault(c => c.CarId == id);
            return car;
        }

        
      public ICollection<Car> GetAllCars()
      {

          var cars = db.Cars.AsQueryable();
          return db.Cars.ToList();
        
     }
      
        public bool DeleteCar(int carId)
        {
            var car = db.Cars.FirstOrDefault(c => c.CarId == carId);
            if (car == null) return false;
            db.Cars.Remove(car);
            db.SaveChanges();
            return true;
        }

        public bool IsCarValid(int carId)
        {
            var car = db.Cars.Find(carId);
            if (car != null) return true;
            return false;
        }

        public void EditCar(Car editCar)
        {    
            db.Cars.Update(editCar);
            db.SaveChanges();
        }

        public IEnumerable<Car> GetSearchedCars(SearchCarsViewModel carCriteria)
        {
            IEnumerable<Car> cars = db.Cars.AsQueryable();
            if(carCriteria.Model != null) cars = cars.Where(x => x.Model == carCriteria.Model);
            if (carCriteria.Make != null) cars = cars.Where(x => x.Make == carCriteria.Make);
            if (carCriteria.MaxPrice != 0) cars = cars.Where(x => x.Price <= carCriteria.MaxPrice);
            if (carCriteria.MinPrice != 0) cars = cars.Where(x => x.Price >= carCriteria.MinPrice);
            if (carCriteria.Mileage != 0) cars = cars.Where(x => x.Mileage <= carCriteria.Mileage);
            if (carCriteria.MaxYear != 0) cars = cars.Where(x => x.Year <= carCriteria.MaxYear);
            if (carCriteria.MinYear != 0) cars = cars.Where(x => x.Year >= carCriteria.MinYear);
            if(carCriteria.Color.ToString()!= null) cars = cars.Where(x => x.Color == carCriteria.Color);
            if (carCriteria.Fuel.ToString() != null) cars = cars.Where(x => x.Fuel == carCriteria.Fuel);
            if (carCriteria.Type.ToString() != null) cars = cars.Where(x => x.Type == carCriteria.Type);
            return cars;
        }
    }
}
