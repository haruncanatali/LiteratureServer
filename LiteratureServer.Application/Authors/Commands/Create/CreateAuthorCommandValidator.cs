using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureServer.Application.Common.Models;

namespace LiteratureServer.Application.Authors.Commands.Create
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(c => c.Fullname).NotEmpty()
                .WithName(GlobalPropertyDisplayName.AuthorName);
            RuleFor(c => c.Bio).NotEmpty()
                .WithName(GlobalPropertyDisplayName.AuthorBio);
        }
    }
}
