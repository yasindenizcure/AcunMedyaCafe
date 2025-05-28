using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class GalleryValidator: AbstractValidator<Gallery>
    {
        public GalleryValidator() 
        {
            RuleFor(x => x.PhotoUrl).NotEmpty().WithMessage("Resim kısmı boş geçilemez.");
        }
    }
}
