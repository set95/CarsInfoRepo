using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsInfoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using CarsInfoWeb.Repositories;
using CarsInfoWeb.ViewModel;
using Microsoft.AspNetCore.Http;
using Type = CarsInfoWeb.Models.CarType;

namespace CarsInfoWeb.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(CarsInfoContext context)
        {
            _repo = new CarsRepositories(context);
        }
        private readonly CarsRepositories _repo;



        public IActionResult Index()
        {

            if (_repo.GetAllCars() != null)
            {
                HomeViewModel view = new HomeViewModel()
                {
                    modelCar = _repo.GetAllCars(),
                    modelSearch = new SearchCarsViewModel()
                };
                return View(view);
            }

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

            return View();
        }


        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Admin()
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
            return RedirectToAction("Login","Login");
        }
    }
}
