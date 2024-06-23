using FluentValidation;
using LiteratureServer.Application.Common.Models;

namespace LiteratureServer.Application.Periods.Commands.Delete;

public class DeletePeriodCommandValidator : AbstractValidator<DeletePeriodCommand>
{
    public DeletePeriodCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithName(GlobalPropertyDisplayName.PeriodId);
    }
}