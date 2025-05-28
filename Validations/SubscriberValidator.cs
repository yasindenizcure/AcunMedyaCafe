using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class SubscriberValidator : AbstractValidator<Subscriber>
    {
        public SubscriberValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta alanı boş geçilemez.")
                .MinimumLength(5).WithMessage("E-posta en az 5 karakter olmalıdır.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
        }
    }
}
