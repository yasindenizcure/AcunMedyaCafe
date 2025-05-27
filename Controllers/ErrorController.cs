using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
