using System;
using System.Collections.Generic;
using System.Linq;
using Event_Aggregator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Event_Aggregator.Controllers
{
    public class DetailsController : Controller
    {
        private readonly Event_AggregatorContext _context;

        public DetailsController(Event_AggregatorContext context) => _context = context;

        public IActionResult Index(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}