using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class AboutValidator: AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık kısmı boş geçilemez.")
                .MinimumLength(3).WithMessage("Başlık kısmı en az 3 karakter olmalıdır.");

            RuleFor(x => x.Subtitle).NotEmpty().WithMessage("Alt Başlık kısmı boş geçilemez.")
                .MinimumLength(3).WithMessage("Başlık kısmı en az 3 karakter olmalıdır.");

            RuleFor(x => x.BoldText).NotEmpty().WithMessage("Ana Başlık kısmı boş geçilemez.")
                .MinimumLength(3).WithMessage("Ana Başlık kısmı en az 3 karakter olmalıdır.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmı boş geçilemez.")
                .MinimumLength(10).WithMessage("Açıklama kısmı en az 10 karakter olmalıdır.");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim kısmı boş geçilemez.");

            RuleFor(x => x.VideoUrl).NotEmpty().WithMessage("Video kısmı boş geçilemez.");

        }
    }
}
