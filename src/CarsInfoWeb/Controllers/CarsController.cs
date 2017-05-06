using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsInfoWeb.Models;
using CarsInfoWeb.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CarsInfoWeb.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsRepositories repo;

        public CarsController(CarsInfoContext context)
        {
            repo = new CarsRepositories(context);
        }

        public IActionResult GetCar(int id)
        {
            var car = repo.GetCar(id);
            if (car == null)
            {
                ViewBag.Message = id;
                return View("NoCarFoudError");
            }
            //ViewBag.Title = car.Brand + " " + car.Brand;

            return View(car);
        }

        
        public IActionResult Index()
        {
            //ViewBag.Title = "Customer List";
            if (repo.GetAllCars() != null)
            { 
                return View(repo.GetAllCars());
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateCar()
        {
            if (User.Identity.IsAuthenticated)
            {
                var newCar = new Car();
                return View(newCar);
            }
            else
            {
               return RedirectToAction("Login","Account");
            }

        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCar(Car newCar)
        {
            if (ModelState.IsValid)
            {
                newCar = repo.CreateCar(newCar);
                return RedirectToAction("GetCar", new { CarId = newCar.CarId });
            }
            return View("CreateCar", newCar);
        }
    }
}
