using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly CafeContext cafeContext;
        private readonly IValidator<Testimonial> validator;

        public TestimonialController(CafeContext cafeContext, IValidator<Testimonial> validator)
        {
            this.cafeContext = cafeContext;
            this.validator = validator;
        }

        public IActionResult Index()
        {
            var values = cafeContext.Testimonials.ToList();
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
            cafeContext.Testimonials.Add(p);
            cafeContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var value = cafeContext.Testimonials.Find(id);
            cafeContext.Remove(value);
            cafeContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var value = cafeContext.Testimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial p)
        {
            cafeContext.Testimonials.Update(p);
            cafeContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}