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

        [HttpGet]
        public IActionResult AcquistaBiglietti(int id)
        {
            var spettatore = new Spettatore();
            spettatore.setidFilm(id);
            return View(spettatore);
        }

        [HttpPost]
        public IActionResult AcquistaBiglietti(Spettatore spettatore)
        {
            
            var bigliettiManager = new BigliettiManager();
            bigliettiManager.aggiungiBiglietto(spettatore);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SvuotaSala(int id)
        {
            var saleManager = new SaleManager();
            saleManager.svuotaSala(id);
            return RedirectToAction("Index");
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