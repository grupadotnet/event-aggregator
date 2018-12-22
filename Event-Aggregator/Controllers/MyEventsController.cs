using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event_Aggregator.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Event_Aggregator.Controllers
{
    public class MyEventsController : Controller
    {
        private Event_AggregatorContext context;
        public MyEventsController(Event_AggregatorContext ctx) => context = ctx;
        [HttpPost]
        
        public IActionResult AddEvent(Event eve) 
        {
            if (ModelState.IsValid)
            {
                context.Event.Add(eve);
                context.SaveChanges();
                ViewBag.Message="added";
                return View("~/Views/Search/AddEvent.cshtml");
            }
            else
            {

                return View();
            }

           
        }
        public IActionResult SearchEvent(Event eve)
        {
            

                return View();
            


        }
    }
}
