using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class NotificationViewComponent : ViewComponent
    {
        private readonly CafeContext _context;

        public NotificationViewComponent(CafeContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = _context.Notifications
                .OrderByDescending(n => n.CreateDate)
                .Take(5)
                .ToList();

            return View(notifications);
        }
    }
}