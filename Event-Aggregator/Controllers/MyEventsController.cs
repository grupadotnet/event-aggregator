using Event_Aggregator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


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
                ViewBag.Message = "added";
                return View("~/Views/Search/AddEvent.cshtml");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult SearchResult(Event eve)
        {
            
           List <string> filtredList = context.Event.Where(x => x.Title.Contains(eve.Title)).Select(x => x.Title ).ToList();
           if(filtredList.Count==0)
            {
                ViewBag.Message = "Brak Wyników";
            }
           else
            {
                ViewBag.Message = filtredList;
            }
           
            return View("~/Views/Search/SearchResult.cshtml");
        }
    }
}
