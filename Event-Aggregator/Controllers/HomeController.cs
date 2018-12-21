using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Event_Aggregator.Models;
using System.Linq;
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

        public async Task<IActionResult> Index()
        {
            var latest = _context.Event.OrderByDescending(x => x.StartDate).Select(x => x);
            return View(await latest.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
