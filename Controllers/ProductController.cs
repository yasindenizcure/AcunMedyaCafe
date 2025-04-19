using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaCafe.Controllers
{
    public class ProductController : Controller
    {
        private readonly CafeContext _context;

        public ProductController(CafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Products.Include(x=>x.Category).ToList();
            return View(values);
        }
    }
}
