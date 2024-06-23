using FluentValidation;
using LiteratureServer.Application.Common.Models;

namespace LiteratureServer.Application.LiteraryTypes.Commands.Delete;

public class DeleteLiteraryTypeCommandValidator : AbstractValidator<DeleteLiteraryTypeCommand>
{
    public DeleteLiteraryTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithName(GlobalPropertyDisplayName.LiteraryTypeId);
    }
}