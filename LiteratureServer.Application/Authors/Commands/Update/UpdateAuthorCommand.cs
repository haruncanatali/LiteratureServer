using LiteratureServer.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureServer.Application.Common.Exceptions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Managers;
using LiteratureServer.Domain.Entities;
using LiteratureServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.Authors.Commands.Update
{
    public class UpdateAuthorCommand : IRequest<BaseResponseModel<Unit>>
    {
        public long AuthorId { get; set; }
        public string Fullname { get; set; }
        public string Bio { get; set; }
        public IFormFile? Photo { get; set; }

        public class Handler : IRequestHandler<UpdateAuthorCommand, BaseResponseModel<Unit>>
        {
            private readonly IApplicationContext _context;
            private readonly FileManager _fileManager;

            public Handler(IApplicationContext context, FileManager fileManager)
            {
                _context = context;
                _fileManager = fileManager;
            }

            public async Task<BaseResponseModel<Unit>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
            {
                Author? author = await _context.Authors
                    .FirstOrDefaultAsync(c => c.Id == request.AuthorId, cancellationToken);

                if (author == null)
                {
                    throw new NotFoundException("Güncellenecek yazar bulunamadı.");
                }

                author.FullName = request.Fullname;
                author.Bio = request.Bio;

                if (request.Photo != null)
                {
                    author.Photo = _fileManager.Upload(request.Photo, FileRoot.AuthorPhoto);
                }

                _context.Authors.Update(author);
                await _context.SaveChangesAsync(cancellationToken);

                return BaseResponseModel<Unit>.Success(Unit.Value,"Yazar başarıyla güncellendi.");
            }
        }
    }
}
