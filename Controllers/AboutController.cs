using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaCafe.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        private readonly CafeContext cafeContext;
        private readonly IValidator<About> validator;

        public AboutController(CafeContext cafeContext, IValidator<About> validator)
        {
            this.cafeContext = cafeContext;
            this.validator = validator;
        }

        public IActionResult Index()
        {
            var values = cafeContext.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAbout(About p) 
        {
                cafeContext.Abouts.Add(p);
                cafeContext.SaveChanges();
                return RedirectToAction("Index");
        }
        public IActionResult DeleteAbout(int id)
        {
            var value = cafeContext.Abouts.Find(id);
            cafeContext.Remove(value);
            cafeContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var value = cafeContext.Abouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About p)
        {
            cafeContext.Abouts.Update(p);
            cafeContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
