using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission12.Models;

namespace Mission12.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private databaseContext databaseContext { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TourForm(string date, int time)
        {
            return View(date, time);
        }

        [HttpPost]
        public IActionResult TourForm(Tour tour)
        {
            if (ModelState.IsValid)
            {
                //TODO update database
                //repo.saveTour(tour);
                return Confirmation();
            }
            else
            {
                //this will throw bc no appointment passed
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //TODO set all this up, ref FilmCollection proj
            //var tour = DbContext.Tours.FirstOrDefault(x => x.Id == id);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Tour tour)
        {
            if (ModelState.IsValid)
            {
                //TODO update database
                //repo.saveTour(tour);
                return Confirmation();
            }
            else
            {
                //this will throw bc no appointment passed
                return View();
            }
        }

        public IActionResult Confirmation()
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
