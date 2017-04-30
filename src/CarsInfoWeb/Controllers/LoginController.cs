using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CarsInfoWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/
        public IActionResult Login()
        {
      
            return View();
        }
        [HttpPost]
        public IActionResult Login(string name, string password)
        {
            if("admin".Equals(name) && "admin".Equals(password))
            {
                Session["user"] = new User() { Login = name, name = "Test Test" };
                return RedirectToAction("AdminPage", "Home");
            }
            return View();
        }

        public IActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
