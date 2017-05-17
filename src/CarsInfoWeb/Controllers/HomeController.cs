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
                    modelCar = _repo.GetLastAddedCars(),
                    carsPictures = _repo.GetAllPictures(),
                };
                return View(view);
            }

            return View();
        }

        public IActionResult About()
        {
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
           return RedirectToAction("Login","Login");
        }
    }
}
