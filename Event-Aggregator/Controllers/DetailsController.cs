using Microsoft.AspNetCore.Mvc;
using Event_Aggregator.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Event_Aggregator.Google;

namespace Event_Aggregator.Controllers
{
    public class DetailsController : Controller
    {
        private readonly Event_AggregatorContext _context;
        private readonly GoogleApiSettings _googleApiSettings;

        public DetailsController(Event_AggregatorContext context, IOptions<GoogleApiSettings> options)
        {
            _googleApiSettings = options.Value;
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            var result = await _context.Event.FirstOrDefaultAsync(x => id.Equals(x.Id));
            ViewBag.ApiKey = _googleApiSettings.ApiKey;
            return View(result);
        }
    }
}