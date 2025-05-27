using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _DefaultAddressComponentPartial: ViewComponent
    {
        private readonly CafeContext _context;
        public _DefaultAddressComponentPartial(CafeContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Addresses.FirstOrDefault();
            return View(values);
        }
    }
}
