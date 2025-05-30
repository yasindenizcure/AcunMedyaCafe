using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class GalleryValidator: AbstractValidator<Gallery>
    {
        public GalleryValidator() 
        {
            RuleFor(x => x.PhotoUrl).NotEmpty().WithMessage("Resim linki boş geçilemez.")
              .MinimumLength(10).WithMessage("Resim linki en az 10 karakter olmalıdır.");
        }
    }
}
