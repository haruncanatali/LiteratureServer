using FluentValidation;
using LiteratureServer.Application.Common.Models;

namespace LiteratureServer.Application.LiteraryTypes.Commands.Update;

public class UpdateLiteraryTypeCommandValidator : AbstractValidator<UpdateLiteraryTypeCommand>
{
    public UpdateLiteraryTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithName(GlobalPropertyDisplayName.LiteraryTypeId);
        RuleFor(c => c.Name).NotEmpty()
            .WithName(GlobalPropertyDisplayName.LiteraryTypeName);
        RuleFor(c => c.Description).NotEmpty()
            .WithName(GlobalPropertyDisplayName.LiteraryTypeDescription);
    }
}