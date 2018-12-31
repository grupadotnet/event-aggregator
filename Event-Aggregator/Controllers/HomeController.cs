﻿using System.Diagnostics;
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

        public async Task<IActionResult> Index(string searchString)
        {
            var latest = _context.Event.OrderByDescending(x => x.StartDate).Take(10);
            if (!string.IsNullOrEmpty(searchString))
            {
                var query = latest.Where(x => x.Title.Contains(searchString) || x.Hash.Contains(searchString) || x.Category.Contains(searchString)).Select(x => x);
                if (!query.Equals(null))
                    latest = query;
                else
                    ViewBag.Message("Nie odnaleziono wyników spełniających kryteria wyszukiwania");
            }

            return View(await latest.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
