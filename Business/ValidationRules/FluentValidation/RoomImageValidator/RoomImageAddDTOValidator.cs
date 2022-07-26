using Entities.DTOs.Concrete.RoomImageDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.RoomImageValidator
{
    public class RoomImageAddDTOValidator : AbstractValidator<RoomImageAddDTO>
    {
        public RoomImageAddDTOValidator()
        {
            RuleFor(r => r.RoomId).NotEmpty().WithMessage($"");
        }
    }
}