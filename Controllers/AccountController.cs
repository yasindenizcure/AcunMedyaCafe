using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using AcunMedyaCafe.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Controllers
{
    public class AccountController : Controller
    {
        private readonly CafeContext _context;

        public AccountController(CafeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users
                    .FirstOrDefault(u => u.Username == model.Username);

                if (existingUser != null)
                {
                    ViewBag.ErrorMessage = "Bu kullanıcı adı zaten kayıtlı!";
                    return View(model);
                }

                var newUser = new User
                {
                    Username = model.Username,
                    Password = model.Password
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                return RedirectToAction("Index", "Category");
            }

            ViewBag.ErrorMessage = "Kayıt başarısız!";
            return View(model);
        }
    }
}