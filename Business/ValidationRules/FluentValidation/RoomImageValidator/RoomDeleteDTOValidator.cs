using Entities.DTOs.Concrete.RoomImageDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.RoomImageValidator
{
    public class RoomImageDeleteDTOValidator : AbstractValidator<RoomImageDeleteDTO>
    {
        public RoomImageDeleteDTOValidator()
        {
            RuleFor(r => r.Id).NotEmpty().WithMessage($"");
        }
    }
}