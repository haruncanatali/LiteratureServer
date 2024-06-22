using FluentValidation;
using LiteratureServer.Application.Common.Models;

namespace LiteratureServer.Application.Auth.Queries.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithName(GlobalPropertyDisplayName.Password);
            RuleFor(x => x.Username).NotEmpty().WithName(GlobalPropertyDisplayName.UserName);
        }
    }
}
