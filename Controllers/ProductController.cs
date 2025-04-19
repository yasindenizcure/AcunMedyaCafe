using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaCafe.Controllers
{
    public class ProductController : Controller
    {
        private readonly CafeContext _context;

        public ProductController(CafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Products.Include(x=>x.Category).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> values =(from x in _context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryId.ToString()
                                          }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product model)
        {
            if (model.ImageFile != null) 
            {
                //uygulamanın çalıştığı dizini al
                var currentDirectory = Directory.GetCurrentDirectory();

                //uygulamanın uzantısını al(jpg,png)
                var extension = Path.GetExtension(model.ImageFile.FileName);

                //benzersiz dosya adı oluştur
                var filename = Guid.NewGuid().ToString();

                //kayıt edilecek dosyanın yolu
                var saveLocation = Path.Combine(currentDirectory, "wwwroot/images", filename + extension);

                //belirtilen konumda bir dosya oluştur
                var stream = new FileStream(saveLocation, FileMode.Create);

                //dosyayı fiziksel olarak sunucuya yazar
                model.ImageFile.CopyTo(stream);


                model.ImageUrl="/images/" + filename + extension; 
            }
            _context.Products.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
