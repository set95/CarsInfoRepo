using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarsInfoWeb.Models;
using CarsInfoWeb.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

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

        public IActionResult GetCar(int id)
        {
            var car = _repo.GetCar(id);
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
            else
            {
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
        public async Task<IActionResult> CreateCar(/*[Bind("Make","Model","Price","Year","Mileage","Color","Fuel","Type")]*/Car newCar, IFormFile pictureFile)
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
                        string fileName = Path.GetFileName(pictureFile.FileName);
                        if (fileName != null)
                        {
                            using (
                                FileStream fs = new FileStream(Path.Combine(uploadPath, user.Id, fileName),
                                    FileMode.Create)
                            )
                            {
                                await pictureFile.CopyToAsync(fs);
                                newCar.Picture = fileName;
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unsupported file format.");
                        return View(newCar);

                    }
                }
                else
                {
                    newCar.Picture = "";
                }
                newCar.UserId = user.Id;
                newCar =  _repo.CreateCar(newCar);
                return RedirectToAction("Index","Cars");
            }
            return View("CreateCar", newCar);
        }
    }
}
