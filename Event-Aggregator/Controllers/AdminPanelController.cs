using System;
using System.Collections.Generic;
using System.Linq;
using Event_Aggregator.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Event_Aggregator.Controllers
{
    public class AdminPanelController : Controller
    {
        private Event_AggregatorContext context;
        public AdminPanelController(Event_AggregatorContext ctx) => context = ctx;
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Panel(User user)
        {
            var query = context.User.Select(x => x).FirstOrDefault();

            if (user.Login.Equals(query.Login) && user.Password.Equals(user.Password))
            {
                return View();
            }
            else
            {
                return View("Index");
            }

        }
    }
}
