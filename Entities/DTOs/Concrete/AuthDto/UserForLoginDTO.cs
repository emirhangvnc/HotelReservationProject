using Core.Entities;

namespace Entities.DTOs.Concrete.AuthDto
{
    public class UserForLoginDTO : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}