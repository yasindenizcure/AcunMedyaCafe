using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _AdminLayoutScriptComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
