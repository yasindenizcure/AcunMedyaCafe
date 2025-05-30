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
        private readonly CafeContext _context;
        private readonly IValidator<About> _validator;

        public AboutController(CafeContext context, IValidator<About> validator)
        {
            _context = context;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var values = _context.Abouts.ToList();
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
            var validationResult = _validator.Validate(p);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(p); // Hatalıysa formu tekrar göster
            }

            _context.Abouts.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            if (value != null)
            {
                _context.Abouts.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About p)
        {
            var validationResult = _validator.Validate(p);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(p); // Hatalıysa formu tekrar göster
            }

            _context.Abouts.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
