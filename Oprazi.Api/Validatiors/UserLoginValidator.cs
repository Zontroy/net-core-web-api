using FluentValidation;
using Oprazi.Dto.DTOs;
using System;
using System.Linq;

namespace Oprazi.Api.Validatiors
{
    public class UserLoginValidator : AbstractValidator<UserLoginToAddDTO>
    {
        public UserLoginValidator()
        {
            // TODO: implement validator in zontroy and regenerate
        }

        private bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
