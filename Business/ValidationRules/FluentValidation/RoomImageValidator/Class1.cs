using Entities.DTOs.Concrete.RoomImageDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.RoomImageValidator
{
    public class RoomImageUpdateDTOValidator : AbstractValidator<RoomImageUpdateDTO>
    {
        public RoomImageUpdateDTOValidator()
        {
            RuleFor(r => r.Id).NotEmpty().WithMessage($"");
            RuleFor(r => r.RoomId).NotEmpty().WithMessage($"");
        }
    }
}