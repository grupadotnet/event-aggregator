using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event_Aggregator.Models;
using Microsoft.AspNetCore.Mvc;


namespace Event_Aggregator.Controllers
{
    public class RegistrationController : Controller
    {
        private Event_AggregatorContext context;
        public RegistrationController(Event_AggregatorContext ctx) => context = ctx;
        [HttpGet]
        public IActionResult Registration() => View("~/Views/Registration/RegistrationPanel.cshtml");
        [HttpPost]
        public IActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Hashing.Hash(user.Password);
                context.User.Add(user);
                context.SaveChanges();
                ViewBag.Message = "added";
                return View("~/Views/Registration/RegistrationPanel.cshtml");
            }
            else
            {
                ViewBag.Message = "sprobój jeszcze raz";
                return View("~/Views/Registration/RegistrationPanel.cshtml");
                
            }
        }
        [HttpGet]
        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {

            var correct = context.User.Where(e => e.Email == user.Email).FirstOrDefault();

            
            if (correct != null)
            {
                if (string.Compare(Hashing.Hash(user.Password), correct.Password) == 0)
                {
                    ViewBag.Message = "Zostales zalogowany";
                    return View();
                }
                else
                {
                    ViewBag.Message = "spróbuj jeszcz raz zle haslo";
                   
                    return View();
                }

            }
            else
            {
                ViewBag.Message = "spróbuj jeszcz raz zly email";
                return View();
            }

        }

        
    }

}
