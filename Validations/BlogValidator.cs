using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class BlogValidator: AbstractValidator<Blog>
    {
        public BlogValidator() 
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog başlığı boş geçilemez.")
                .MinimumLength(3).WithMessage("Blog başlığı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Blog başlığı boş geçilemez.")
                .MinimumLength(3).WithMessage("Blog başlığı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog içeriği boş geçilemez.")
                .MinimumLength(3).WithMessage("Blog içeriği en az 3 karakter olmalıdır.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Blog görseli boş geçilemez.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Blog görseli boş geçilemez.");
        }
    }
}
