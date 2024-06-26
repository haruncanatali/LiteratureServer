﻿using FluentValidation;
using LiteratureServer.Application.Common.Models;

namespace LiteratureServer.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithName(GlobalPropertyDisplayName.UpdateId);
            RuleFor(x => x.FirstName).NotEmpty().WithName(GlobalPropertyDisplayName.FirstName);
            RuleFor(x => x.Surname).NotEmpty().WithName(GlobalPropertyDisplayName.LastName);
            RuleFor(x => x.Email).EmailAddress().WithName(GlobalPropertyDisplayName.Email);
            RuleFor(c => c.Gender).NotNull().WithMessage(GlobalPropertyDisplayName.Gender);
            RuleFor(c => c.Birthdate).NotNull().WithMessage(GlobalPropertyDisplayName.Birthdate);
        }
    }
}
