using System.ComponentModel.DataAnnotations.Schema;

namespace AcunMedyaCafe.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int ProductPrice { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped] //veri tabanına kaydetmez
        public IFormFile ImageFile { get; set; } // kullanıcının yüklediği dosyayı temsil eder.    
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
