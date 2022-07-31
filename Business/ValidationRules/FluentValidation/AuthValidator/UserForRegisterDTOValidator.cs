using Entities.DTOs.Concrete.AuthDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.AuthValidator
{
    public class UserForRegisterDTOValidator : AbstractValidator<UserForRegisterDTO>
    {
        public UserForRegisterDTOValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage($"");
            RuleFor(u => u.FirstName).MaximumLength(50).WithName($"");
            RuleFor(u => u.LastName).NotEmpty().WithMessage($"");
            RuleFor(u => u.LastName).MaximumLength(50).WithName($"");
            RuleFor(u => u.Email).NotNull().WithMessage($"");
            RuleFor(u => u.Email).MaximumLength(60).WithName($"");
            RuleFor(u => u.Password).NotNull();
        }
    }
}