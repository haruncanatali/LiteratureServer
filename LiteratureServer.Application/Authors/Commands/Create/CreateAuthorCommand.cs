using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Managers;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Entities;
using LiteratureServer.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LiteratureServer.Application.Authors.Commands.Create
{
    public class CreateAuthorCommand : IRequest<BaseResponseModel<Unit>>
    {
        public string Fullname { get; set; }
        public string Bio { get; set; }
        public IFormFile? Photo { get; set; }

        public class Handler : IRequestHandler<CreateAuthorCommand, BaseResponseModel<Unit>>
        {
            private readonly IApplicationContext _context;
            private readonly FileManager _fileManager;

            public Handler(IApplicationContext context, FileManager fileManager)
            {
                _context = context;
                _fileManager = fileManager;
            }

            public async Task<BaseResponseModel<Unit>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
            {
                await _context.Authors.AddAsync(new Author
                {
                    FullName = request.Fullname,
                    Bio = request.Bio,
                    Photo = _fileManager.Upload(request.Photo, FileRoot.AuthorPhoto)
                });

                await _context.SaveChangesAsync(cancellationToken);

                return BaseResponseModel<Unit>.Success(Unit.Value,"Yazar başarıyla eklendi.");
            }
        }
    }
}
