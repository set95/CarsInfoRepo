﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarsInfoWeb.Models;
using CarsInfoWeb.Repositories;
using CarsInfoWeb.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Vereyon.Web;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CarsInfoWeb.Controllers
{
    public class CarsController : Controller
    {
        private SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CarsRepositories _repo;
        private readonly IHostingEnvironment _environment;

        public CarsController(CarsInfoContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHostingEnvironment environment)
        {
            _repo = new CarsRepositories(context);
            _userManager = userManager;
            _signInManager = signInManager;
            _environment = environment;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetMyCars()
        {
            var user = await _userManager.GetUserAsync(User);
            var myCars =  _repo.GetMyCars(user.Id);
            if (myCars == null)
            {
                ViewBag.Message = "You have not added any cars";
                return View();
            }
  
            return View(myCars);
        }

        
        public IActionResult Index()
        {
            //ViewBag.Title = "Customer List";
            if (_repo.GetAllCars() != null)
            { 
                return View(_repo.GetAllCars());
            }
            return View();
        }
        

        [HttpGet]
        public IActionResult CreateCar()
        {
            if (User.Identity.IsAuthenticated)
            {
                var newCar = new Car();
                return View();
            }
            else{
               return RedirectToAction("Login","Account");
                }
        }

        public async Task<string> GetCurrentUserId()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            return usr?.Id;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCar(Car newCar, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (pictureFile != null)
                {
                    var extension = Path.GetExtension(pictureFile.FileName).ToLower();

                    if ((extension == ".jpg") || (extension == ".png") || (extension == ".jpeg") ||
                        (extension == ".gif"))
                    {
                        var uploadPath = Path.Combine(_environment.WebRootPath, "users_uploads");
                        Directory.CreateDirectory(Path.Combine(uploadPath, user.Id));
                        if (Path.GetFileName(pictureFile.FileName) != null)
                        {
                            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(pictureFile.FileName);//Path.GetFileName(pictureFile.FileName); //Guid.NewGuid().ToString();

                            using (FileStream fs = new FileStream(Path.Combine(uploadPath, user.Id, fileName),FileMode.Create))
                            {
                                await pictureFile.CopyToAsync(fs);
                                newCar.Picture = fileName;
                            }
                        }
                    }
                    else{
                        ModelState.AddModelError("", "Unsupported file format.");
                        return View(newCar);                  
                    }
                }
                else{
                    newCar.Picture = "";
                }
                newCar.UserId = user.Id;
               // newCar.DateTimeAdded = DateTime.Now;

                newCar =  _repo.CreateCar(newCar);
                return RedirectToAction("Index","Cars");
            }
            return View("CreateCar", newCar);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int id)
        {
            bool carExist = _repo.DeleteCar(id);
                if (carExist)//User.IsInRole("Admin") 
            {
                 
                return RedirectToAction("Index","Cars");
            }
            else
                {
                    ViewBag.error = "There is no car with this ID";
                return View("Index",_repo.GetAllCars());
            }

        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            
            if (_repo.IsCarValid(id))
            {
                Car car = _repo.GetCar(id);
                return View("Edit",car);
            }
            else
            {
                ViewBag.error = "There is no car with this ID";
                return View("Index", _repo.GetAllCars());
            }

        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Car car, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (pictureFile != null)
                {
                    var extension = Path.GetExtension(pictureFile.FileName).ToLower();

                    if ((extension == ".jpg") || (extension == ".png") || (extension == ".jpeg") ||
                        (extension == ".gif"))
                    {
                        var userFolderPath = Path.Combine(_environment.WebRootPath, "users_uploads",user.Id);
                        if ((car.Picture!= null )&&(car.Picture!=""))
                        {
                            var filePath = Path.Combine(_environment.WebRootPath, "users_uploads", user.Id, car.Picture);
                            System.IO.File.Delete(filePath);
                        }
                       

                        if (Path.GetFileName(pictureFile.FileName) != null)
                        {
                            string fileName = Guid.NewGuid().ToString()+ extension; //Path.GetFileName(pictureFile.FileName));

                            using (FileStream fs = new FileStream(Path.Combine(userFolderPath, fileName), FileMode.Create))
                            {
                                await pictureFile.CopyToAsync(fs);
                                car.Picture = fileName;
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unsupported file format.");
                        return View(car);
                    }
                }
                else
                {
                    car.Picture = "";
                }

                _repo.EditCar(car);
                return RedirectToAction("Index", "Cars");
            }
            return View("Edit", car);
        }

        [HttpGet]
        public IActionResult GetCarsByCriteria(SearchCarsViewModel car)
        {
           // bool test = (Color.White.ToString() == "White"); 
            if (ModelState.IsValid)
            {
            IEnumerable<Car> cars  = _repo.GetSearchedCars(car);
                return View("Index",cars);
            }
            return View("Index",_repo.GetAllCars());
        }

    }
}
