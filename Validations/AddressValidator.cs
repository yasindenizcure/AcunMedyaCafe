using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class AddressValidator: AbstractValidator<Address>
    {
        public AddressValidator() 
        {
            RuleFor(x => x.WeekdayHours).NotEmpty().WithMessage("Hafta içi çalışma saatleri boş geçilemez.");
            RuleFor(x => x.WeekendHours).NotEmpty().WithMessage("Hafta sonu çalışma saatleri boş geçilemez.");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş geçilemez.")
            .MinimumLength(10).WithMessage("Telefon Numarası en az 10 karakter olmalıdır!");

        }
    }
}
