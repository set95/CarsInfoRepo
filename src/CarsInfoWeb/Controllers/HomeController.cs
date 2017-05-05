using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsInfoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace CarsInfoWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly CarsInfoContext _context;

        public HomeController(CarsInfoContext context)
        {
            _context = context;
        }

        public Car car = new Car()
        {
            Brand = "Ford",
            Model = "Focus",
            Price = 4000M,
            Year = 2002,
            Mileage = 200000,
            Color = "Ford",
            CatalogId = 1,
            Fuel = "diesel",
            Type = "sedan"
        };

       
        public IActionResult Index()
        {
            //if(HttpContext.Session.GetString("user") == null)
           // {
           //     return RedirectToAction("Login", "Login");
          //  }
            return View();
        }

        public IActionResult About()
        {
            /*
            _context.CatalogCars.Add(new CarsCatalog()
            {
                Cars = new List<Vehicle>()
            });
            _context.SaveChanges();
            _context.Cars.Add(car);
            
            ViewData["Message"] = _context.CatalogCars.Count();
            _context.SaveChanges();
            */
            return View();
        }

        public IActionResult Contact(IEnumerable<Car> car)
        {
            ViewData["Message"] = "Your contact page.";

            return View(_context.Cars);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
