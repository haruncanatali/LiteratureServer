using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureServer.Application.Common.Exceptions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Managers;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.Authors.Commands.Delete
{
    public class DeleteAuthorCommand : IRequest<BaseResponseModel<Unit>>
    {
        public long AuthorId { get; set; }

        public class Handler : IRequestHandler<DeleteAuthorCommand, BaseResponseModel<Unit>>
        {
            private readonly IApplicationContext _context;
            private readonly FileManager _fileManager;

            public Handler(IApplicationContext applicationContext, FileManager fileManager)
            {
                _context = applicationContext;
                _fileManager = fileManager;
            }

            public async Task<BaseResponseModel<Unit>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
            {
                Author? author = await _context.Authors
                    .Include(c=>c.Literaries)
                    .FirstOrDefaultAsync(c => c.Id == request.AuthorId, cancellationToken: cancellationToken);

                if (author == null)
                {
                    throw new NotFoundException("Silinecek yazar bulunamadı.");
                }

                if (author.Literaries is {Count: > 0})
                {
                    _context.Literaries.RemoveRange(author.Literaries);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                
                _fileManager.Delete(author.Photo);
                await _context.SaveChangesAsync(cancellationToken);

                return BaseResponseModel<Unit>.Success(Unit.Value,"Yazar başarıyla silindi.");
            }
        }
    }
}
