using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class FeatureValidator: AbstractValidator<Feature>
    {
        public FeatureValidator() 
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez.")
                .MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır.");
            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Alt başlık boş geçilemez.")
                .MinimumLength(3).WithMessage("Alt Başlık en az 3 karakter olmalıdır.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel boş geçilemez.");
        }
    }
}
