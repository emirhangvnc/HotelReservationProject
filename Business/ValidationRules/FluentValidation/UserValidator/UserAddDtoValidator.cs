using Entities.DTOs.Concrete.UserDTO;
using FluentValidation;

namespace Business.ValidationRules.EntiFluentValidation.UserValidator
{
    public class UserAddDtoValidator : AbstractValidator<UserAddDTO>
    {
        public UserAddDtoValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage($"");
            RuleFor(u => u.FirstName).MaximumLength(50).WithName($"");
            RuleFor(u => u.LastName).NotEmpty().WithMessage($"");
            RuleFor(u => u.LastName).MaximumLength(50).WithName($"");
            RuleFor(u => u.Email).NotNull().WithMessage($"");
            RuleFor(u => u.Email).MaximumLength(60).WithName($"");
            RuleFor(u => u.Status).NotNull();
        }
    }
}