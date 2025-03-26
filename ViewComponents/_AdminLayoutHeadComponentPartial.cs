using Microsoft.AspNetCore.Mvc;
namespace AcunMedyaCafe.ViewComponents
{
    public class _AdminLayoutHeadComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
