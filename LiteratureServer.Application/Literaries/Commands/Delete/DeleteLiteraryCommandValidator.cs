using FluentValidation;
using LiteratureServer.Application.Common.Models;

namespace LiteratureServer.Application.Literaries.Commands.Delete;

public class DeleteLiteraryCommandValidator : AbstractValidator<DeleteLiteraryCommand>
{
    public DeleteLiteraryCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithName(GlobalPropertyDisplayName.LiteraryId);
    }
}