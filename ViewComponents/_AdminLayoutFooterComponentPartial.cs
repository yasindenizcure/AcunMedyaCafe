using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _AdminLayoutFooterComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
