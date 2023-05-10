using FluentValidation;
using Oprazi.Dto.DTOs;
using System;
using System.Linq;

namespace Oprazi.Api.Validatiors
{
    public class UserValidator : AbstractValidator<UserToAddDTO>
    {
        public UserValidator()
        {
            RuleFor(m => m.UserName).NotEmpty().WithMessage("Username must be fill");
        }

        private bool IsValidName(string name)
        {
            ///TODO:fix for null values
            if (name == null)
                return true;
            return name.All(Char.IsLetter);
        }
    }
}
