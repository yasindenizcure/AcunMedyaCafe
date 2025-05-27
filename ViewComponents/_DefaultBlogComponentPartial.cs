using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaCafe.ViewComponents
{
    public class _DefaultBlogComponentPartial: ViewComponent
    {
        private readonly CafeContext _cafeContext;

        public _DefaultBlogComponentPartial(CafeContext cafeContext)
        {
            _cafeContext = cafeContext;
        }
        public IViewComponentResult Invoke()
        {
            var values = _cafeContext.Blogs.ToList();
            return View(values);
        }
    }
}
