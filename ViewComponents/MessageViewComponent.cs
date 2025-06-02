using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaCafe.ViewComponents
{
    public class MessageViewComponent: ViewComponent
    {
        private readonly CafeContext _context;

        public MessageViewComponent(CafeContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var messages = await _context.Messages.OrderByDescending(x => x.Date).Take(3).ToListAsync();
            return View(messages);

        }
    }
}

