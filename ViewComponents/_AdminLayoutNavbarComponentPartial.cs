using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _AdminLayoutNavbarComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
