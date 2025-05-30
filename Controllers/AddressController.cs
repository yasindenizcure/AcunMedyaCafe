using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Controllers
{
    [Authorize]
    public class AddressController : Controller
    {
        private readonly CafeContext _context;
        private readonly IValidator<Address> _validator;

        public AddressController(CafeContext context, IValidator<Address> validator)
        {
            _context = context;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var values = _context.Addresses.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAddress()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAddress(Address p)
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

            _context.Addresses.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAddress(int id)
        {
            var value = _context.Addresses.Find(id);
            if (value != null)
            {
                _context.Addresses.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAddress(int id)
        {
            var value = _context.Addresses.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAddress(Address p)
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

            _context.Addresses.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}