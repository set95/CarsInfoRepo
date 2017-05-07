﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using CarsInfoWeb.Models;
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
            //Car car = db.Cars.FirstOrDefault(c => c.CarId == editCar.CarId);
           // if (editCar.Picture == "") editCar.Picture = car.Picture;
            db.Cars.Update(editCar);
            db.SaveChanges();
        }
    }
}
