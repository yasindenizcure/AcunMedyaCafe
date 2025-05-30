using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Controllers
{
    [Authorize]
    public class SocialMediaController : Controller
    {
        private readonly CafeContext _context;
        private readonly IValidator<SocialMedia> _validator;

        public SocialMediaController(CafeContext context, IValidator<SocialMedia> validator)
        {
            _context = context;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var values = _context.SocialMedias.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia p)
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

            _context.SocialMedias.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            if (value != null)
            {
                _context.SocialMedias.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia p)
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

            _context.SocialMedias.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}