using FluentValidation;
using LiteratureServer.Application.Common.Models;

namespace LiteratureServer.Application.Literaries.Commands.Create;

public class CreateLiteraryCommandValidator : AbstractValidator<CreateLiteraryCommand>
{
    public CreateLiteraryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithName(GlobalPropertyDisplayName.LiteraryName);
        RuleFor(c => c.Description).NotEmpty()
            .WithName(GlobalPropertyDisplayName.LiteraryDescription);
        RuleFor(c => c.PageCount).NotEmpty()
            .WithName(GlobalPropertyDisplayName.LiteraryPageCount);
        RuleFor(c => c.LiteraryTypeId).NotNull()
            .WithName(GlobalPropertyDisplayName.LiteraryTypeId);
        RuleFor(c => c.PeriodId).NotNull()
            .WithName(GlobalPropertyDisplayName.LiteraryPeriodId);
        RuleFor(c => c.AuthorId).NotEmpty()
            .WithName(GlobalPropertyDisplayName.LiteraryAuthorId);
    }
}