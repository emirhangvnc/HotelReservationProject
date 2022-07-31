using Entities.DTOs.Concrete.AuthDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.AuthValidator
{
    public class UserForLoginDTOValidator : AbstractValidator<UserForLoginDTO>
    {
        public UserForLoginDTOValidator()
        {
            RuleFor(u => u.Email).NotNull().WithMessage($"");
            RuleFor(u => u.Email).MaximumLength(60).WithName($"");
            RuleFor(u => u.Password).NotNull();
        }
    }
}