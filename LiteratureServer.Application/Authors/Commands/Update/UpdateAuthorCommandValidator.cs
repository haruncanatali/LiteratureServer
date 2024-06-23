using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LiteratureServer.Application.Common.Models;

namespace LiteratureServer.Application.Authors.Commands.Update
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(c => c.AuthorId).NotNull()
                .WithName(GlobalPropertyDisplayName.AuthorId);
            RuleFor(c => c.Fullname).NotEmpty()
                .WithName(GlobalPropertyDisplayName.AuthorName);
            RuleFor(c => c.Bio).NotEmpty()
                .WithName(GlobalPropertyDisplayName.AuthorBio);
        }
    }
}
