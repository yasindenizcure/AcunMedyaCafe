using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly CafeContext _context;

        public SubscriberController(CafeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscriber([FromForm] Subscriber model)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(model.Email))
            {
                return Json(new { success = false, message = "Lütfen geçerli bir email adresi girin." });
            }

            var exists = _context.Subscribers.Any(x => x.Email == model.Email);
            if (!exists)
            {
                _context.Subscribers.Add(model);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Kayıt başarıyla oluşturuldu." });
            }
            else
            {
                return Json(new { success = false, message = "Bu email adresi zaten kayıtlı." });
            }
        }
    }
}