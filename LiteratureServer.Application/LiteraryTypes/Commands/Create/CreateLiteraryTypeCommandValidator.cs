using FluentValidation;
using LiteratureServer.Application.Common.Models;

namespace LiteratureServer.Application.LiteraryTypes.Commands.Create;

public class CreateLiteraryTypeCommandValidator : AbstractValidator<CreateLiteraryTypeCommand>
{
    public CreateLiteraryTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithName(GlobalPropertyDisplayName.LiteraryTypeName);
        RuleFor(c => c.Description).NotEmpty()
            .WithName(GlobalPropertyDisplayName.LiteraryTypeDescription);
    }
}