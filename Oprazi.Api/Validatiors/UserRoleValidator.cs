using FluentValidation;
using Oprazi.Dto.DTOs;
using System;
using System.Linq;

namespace Oprazi.Api.Validatiors
{
    public class UserRoleValidator : AbstractValidator<UserRoleToAddDTO>
    {
        public UserRoleValidator()
        {
            // TODO: implement validator in zontroy and regenerate
        }

        private bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
