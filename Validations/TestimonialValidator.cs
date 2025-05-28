using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class TestimonialValidator: AbstractValidator<Testimonial>
    {
        public TestimonialValidator() 
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.")
                .MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.")
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim alanı boş geçilemez.");
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Puanlama kısmı boş geçilemez.");
        }
    }
}
