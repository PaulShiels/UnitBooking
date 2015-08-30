using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookinSystem.Models
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("Please enter an email address");

            RuleFor(x => x.Password).NotNull().WithMessage("Please enter your password");
        }
    }
}