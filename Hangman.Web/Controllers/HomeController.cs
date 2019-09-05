using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hangman.Web.Models;
using Hangman.Business.Interface;

namespace Hangman.Web.Controllers
{
    public class HomeController : Controller
    {

        private IPlayerBusiness _playerBusiness;
        public HomeController(IPlayerBusiness playerBusiness)
        {
            _playerBusiness = playerBusiness;
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                _playerBusiness.AddPlayer(model.ToPlayer());
                return RedirectToAction("Index", "Game");
            }
            else
                return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
