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
        public async Task<IActionResult> AddSubscriber(Subscriber model)
        {
            Console.WriteLine("Gelen email: " + model.Email);

            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Default");

            var exists = _context.Subscribers.Any(x => x.Email == model.Email);
            if (!exists)
            {
                _context.Subscribers.Add(model);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Default");
        }
    }
}