using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangman.Business.Interface;
using Hangman.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hangman.Web.Controllers
{
    public class GameController : Controller
    {
        IGameBusiness _gameBusiness;
        public GameController(IGameBusiness gameBusiness)
        {
            _gameBusiness = gameBusiness;
        }
        public IActionResult Index()
        {
            var game = _gameBusiness.RandomWord();

            return View(game);
        }

        [HttpPost]
        public JsonResult Play(PlayStatusViewModel model)
        {
           var result = _gameBusiness.Play(model.ToModel());

            return Json(result);
        }
    }
}