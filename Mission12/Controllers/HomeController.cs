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

        private TourContext tourContext { get; set; }

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
            var newTour = new Tour() { Date = date, Time = time };
            return View(newTour);
        }

        [HttpPost]
        public IActionResult TourForm(Tour tour)
        {
            if (ModelState.IsValid)
            {
                
                tourContext.Add(tour);
                tourContext.SaveChanges();
                return Confirmation();
            }
            else
            {
                return View(tour);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            var tour = tourContext.Tours.FirstOrDefault(x => x.Id == id);
            return View("TourForm",tour);
        }

        [HttpPost]
        public IActionResult Edit(Tour tour)
        {
            if (ModelState.IsValid)
            {
                
                tourContext.Update(tour);
                tourContext.SaveChanges();
                return Confirmation();
            }
            else
            {
                return View("TourForm",tour);
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
