﻿using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Controllers
{
    [Authorize]
    public class TestimonialController : Controller
    {
        private readonly CafeContext _context;
        private readonly IValidator<Testimonial> _validator;

        public TestimonialController(CafeContext context, IValidator<Testimonial> validator)
        {
            _context = context;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var values = _context.Testimonials.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial p)
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

            _context.Testimonials.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            if (value != null)
            {
                _context.Testimonials.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial p)
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

            _context.Testimonials.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}