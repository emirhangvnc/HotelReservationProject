﻿using Core.Entities;

namespace Entities.DTOs.Concrete.AuthDTO
{
    public class UserForRegisterDTO : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}