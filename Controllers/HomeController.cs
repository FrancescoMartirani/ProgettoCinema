using Microsoft.AspNetCore.Mvc;
using ProgettoCinema.Models;
using ProgettoCinema.Manager;
using System.Diagnostics;

namespace ProgettoCinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cinemaManager = new CinemaManager();
            return View(cinemaManager.getAllCinemas());
        }

        [HttpGet]
        public IActionResult VisualizzaSale(int idCinema)
        {
            var saleManager = new SaleManager();
            return View(saleManager.getSale(idCinema));

        }
        [HttpGet]
        public IActionResult VisualizzaFilmCinema(int idCinema)
        {
            var filmManager = new FilmManager();
            return View(filmManager.getCinemaFilm(idCinema));

        }

        [HttpGet]
        public IActionResult VisualizzaFilmSala(int idSala)
        {
            var filmManager = new FilmManager();
            return View(filmManager.getSalaFilm(idSala));

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}