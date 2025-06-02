using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Controllers
{
    [Authorize]
    public class GalleryController : Controller
    {
        private readonly CafeContext _context;
        private readonly IValidator<Gallery> _validator;

        public GalleryController(CafeContext context, IValidator<Gallery> validator)
        {
            _context = context;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var values = _context.Galleries.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGallery()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGallery(Gallery p)
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

            _context.Galleries.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteGallery(int id)
        {
            var value = _context.Galleries.Find(id);
            if (value != null)
            {
                _context.Galleries.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateGallery(int id)
        {
            var value = _context.Galleries.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateGallery(Gallery p)
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

            _context.Galleries.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}