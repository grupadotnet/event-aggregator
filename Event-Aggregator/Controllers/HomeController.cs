using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Event_Aggregator.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Event_Aggregator.Controllers
{
    public class HomeController : Controller
    {
        private readonly Event_AggregatorContext _context;

        public HomeController(Event_AggregatorContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, string categoryString)
        {
            var latest = _context.Event.Where(c => c.Approved.Equals(true)).Include(c => c.Category).OrderByDescending(x => x.StartDate).Take(10);
            //searching process...
            var query = latest.Where(x => x.ShortTitle.Contains(searchString) || x.Category.CategoryName.Equals(categoryString) 
                        || x.Category.CategoryName.Contains(searchString)).Select(x => x);

            if (!(query.Count() == 0))
                latest = query;
            else
                ViewBag.Message = "Nie odnaleziono wyników spełniających kryteria wyszukiwania.";


            ViewData["Categories"] = await _context.Category.Select(x => x).ToListAsync();
            var events = await latest.ToListAsync();
            ModelsWrapper mw = new ModelsWrapper();
            mw.Events = events;
            return View(mw);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
