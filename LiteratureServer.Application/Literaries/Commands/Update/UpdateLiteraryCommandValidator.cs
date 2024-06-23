using FluentValidation;
using LiteratureServer.Application.Common.Models;

namespace LiteratureServer.Application.Literaries.Commands.Update;

public class UpdateLiteraryCommandValidator : AbstractValidator<UpdateLiteraryCommand>
{
    public UpdateLiteraryCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithName(GlobalPropertyDisplayName.LiteraryId);
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