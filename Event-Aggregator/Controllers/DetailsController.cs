using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Event_Aggregator.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Event_Aggregator.Controllers
{
    public class DetailsController : Controller
    {
        private readonly Event_AggregatorContext _context;

        public DetailsController(Event_AggregatorContext context) => _context = context;

        public async Task<IActionResult> Index(int id)
        {
            var query = _context.Event.Where(x => id.Equals(x.Id)).Select(x => x).Take(1);
            return View(await query.ToListAsync());
        }
    }
}