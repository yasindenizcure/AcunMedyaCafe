using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator() 
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün kısmı boş geçilemez.")
                            .MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez.")
                .MinimumLength(3).WithMessage("Ürün açıklaması en az 3 karakter olmalıdır.");

            RuleFor(x => x.ProductPrice).NotEmpty().WithMessage("Fiyat kısmı boş geçilemez.")
                .GreaterThan(0).WithMessage("Ürün Fiyatı 0 TL'den büyük olmalıdır.");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Fiyat kısmı boş geçilemez.");

            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori kısmı boş geçilemez.")
            .GreaterThan(0).WithMessage("Lütfen geçerli bir kategori seçin!");
        }
    }
}
