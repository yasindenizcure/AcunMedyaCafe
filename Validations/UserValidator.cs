using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class UserValidator: AbstractValidator<Entities.User>
    {public UserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez!")
       .MinimumLength(3).WithMessage("Kullanıcı Adı en az 3 karakter olmalıdır!");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez!")
                .MinimumLength(5).WithMessage("Şifre en az 5 karakter olmalıdır!");
        }

    }
}
