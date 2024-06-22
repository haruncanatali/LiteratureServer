using FluentValidation;
using LiteratureServer.Application.Common.Models;

namespace LiteratureServer.Application.Auth.Queries.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(c => c.RefreshToken).NotEmpty()
            .WithName(GlobalPropertyDisplayName.RefreshTokenValue);
    }
}