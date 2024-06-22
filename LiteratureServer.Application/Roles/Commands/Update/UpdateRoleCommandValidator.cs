using FluentValidation;
using LiteratureServer.Application.Common.Models;

namespace LiteratureServer.Application.Roles.Commands.Update;

public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithName(GlobalPropertyDisplayName.RoleName);
        RuleFor(c => c.Id).NotNull()
            .WithName(GlobalPropertyDisplayName.RoleId);
    }
}