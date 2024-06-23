using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LiteratureServer.Application.Common.Models;

namespace LiteratureServer.Application.Authors.Commands.Delete
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(c => c.AuthorId).NotNull()
                .WithName(GlobalPropertyDisplayName.AuthorId);
        }
    }
}
