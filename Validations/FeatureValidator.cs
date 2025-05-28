using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class FeatureValidator: AbstractValidator<Feature>
    {
        public FeatureValidator() 
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık kısmı boş geçilemez.");

            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Alt başlık kısmı boş geçilemez.");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim kısmı boş geçilemez.");
        }
    }
}
