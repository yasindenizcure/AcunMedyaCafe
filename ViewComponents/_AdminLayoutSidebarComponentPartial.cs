using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _AdminLayoutSidebarComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
