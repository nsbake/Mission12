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

        private TourContext tourContext { get; set; }

        //private databaseContext databaseContext {  get; set; }

        public HomeController(TourContext newContext)
        {
            tourContext = newContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            ViewBag.date = DateTime.UtcNow.ToString("yyyy-MM-dd");

            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Date date)
        {
            ViewBag.date = date.DateStr;

            return View();
        }

        [Route("TourForm/{date}/{time:int}")]
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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var selectedTour = tourContext.Tours.Single(x => x.Id == id);

            return View("DeleteConfirmation", selectedTour);
        }
        [HttpPost]
        public IActionResult Delete(Tour tr)
        {
            tourContext.Tours.Remove(tr);
            tourContext.SaveChanges();

            return RedirectToAction("Appointments");
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        public IActionResult Appointments()
        {
            var listAppointments = tourContext.Tours.ToList();

            return View(listAppointments);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
