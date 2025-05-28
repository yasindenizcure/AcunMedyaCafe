using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class SocialMediaValidator: AbstractValidator<SocialMedia>
    {
        public SocialMediaValidator() 
        {
            RuleFor(x => x.Url).NotEmpty().WithMessage("Hesap linki boş geçilemez.");

            RuleFor(x => x.Icon).NotEmpty().WithMessage("Resim boş geçilemez.");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Platform adı boş geçilemez.");

        }
    }
}
