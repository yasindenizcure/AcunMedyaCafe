using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Controllers
{
    [Authorize]
    public class FeatureController : Controller
    {
            private readonly CafeContext _context;
            private readonly IValidator<Feature> _validator;

            public FeatureController(CafeContext context, IValidator<Feature> validator)
            {
                _context = context;
                _validator = validator;
            }

            public IActionResult Index()
            {
                var values = _context.Features.ToList();
                return View(values);
            }

            [HttpGet]
            public IActionResult AddFeature()
            {
                return View();
            }

            [HttpPost]
            public IActionResult AddFeature(Feature p)
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

                _context.Features.Add(p);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            public IActionResult DeleteFeature(int id)
            {
                var value = _context.Features.Find(id);
                if (value != null)
                {
                    _context.Features.Remove(value);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            [HttpGet]
            public IActionResult UpdateFeature(int id)
            {
                var value = _context.Features.Find(id);
                return View(value);
            }

            [HttpPost]
            public IActionResult UpdateFeature(Feature p)
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

                _context.Features.Update(p);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }