using FluentValidation;
using LiteratureServer.Application.Common.Models;

namespace LiteratureServer.Application.Periods.Commands.Create;

public class CreatePeriodCommandValidator : AbstractValidator<CreatePeriodCommand>
{
    public CreatePeriodCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithName(GlobalPropertyDisplayName.PeriodName);
        RuleFor(c => c.Description).NotEmpty()
            .WithName(GlobalPropertyDisplayName.PeriodDescripton);
    }
}