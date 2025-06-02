using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AcunMedyaCafe.Context;

namespace AcunMedyaCafe.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly CafeContext cafeContext;

        public DashboardController(CafeContext cafeContext)
        {
            this.cafeContext = cafeContext;
        }

        public IActionResult Index()
        {
            ViewBag.ProductCount = cafeContext.Products.Count();
            ViewBag.TestimonialCount = cafeContext.Testimonials.Count();
            ViewBag.SubscriberCount = cafeContext.Subscribers.Count();
            var subscribers = cafeContext.Subscribers.OrderByDescending(x=>x.SubscriberId).Take(5).ToList();
            return View(subscribers);
        }
    }
}
