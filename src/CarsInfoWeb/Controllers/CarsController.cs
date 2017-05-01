using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsInfoWeb.Models;
using CarsInfoWeb.Repositories;
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

            return View(repo.GetAllCars());
        }

        //[HttpGet]
        //public IActionResult CreateCustomer()
        //{
        //    var newCustomer = new DimCustomer();
        //    return View(newCustomer);
        //}
    }
}
