using Entities.DTOs.Concrete.UserDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.UserValidator
{
    public class UserDeleteDTOValidator : AbstractValidator<UserDeleteDTO>
    {
        public UserDeleteDTOValidator()
        {
            RuleFor(u => u.Id).NotEmpty().WithMessage($"");
        }
    }
}