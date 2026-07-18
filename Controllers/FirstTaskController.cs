using Microsoft.AspNetCore.Mvc;
using ProgrammingPractice_L20.Models;

namespace ProgrammingPractice_L20.Controllers
{
    public class FirstTaskController : Controller
    {
        private IConfiguration _config;

        public FirstTaskController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult MainPage()
        {
            ViewBag.Aythor = _config["Settings:Aythor"];
            ViewBag.Title = _config["Settings:Title"];
            ViewBag.Year = _config["Settings:Year"];

            return View();
        }

        public IActionResult GameInfo(int id)
        {
            ViewBag.Message = "Такой игры не существует!";
            IActionResult result = id switch
            {
                1 => View("Expedition"),
                2 => View("DetroitBecomeHuman"),
                3 => View("Dispatch"),
                4 => View("Cyberpunk"),
                5 => View("HeroesOfMightAndMagic"),
                6 => View("Sekiro"),
                _ => View("Error")
            };

            return result;
        }

        public IActionResult Error(int? statusCode)
        {
            if (statusCode == 404)
                ViewBag.Message = "Страница не найдена!";
            else
                ViewBag.Message = "Что-то пошло не так!";

            return View("Error");
        }
    }
}
