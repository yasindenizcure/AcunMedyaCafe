using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _DefaultSubscriberComponentPartial: ViewComponent
    {
        private readonly CafeContext _context;

        public _DefaultSubscriberComponentPartial(CafeContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(new Subscriber());
        }
    }
}
