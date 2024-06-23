using LiteratureServer.Application.Common.Exceptions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.Literaries.Commands.Create;

public class CreateLiteraryCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Name { get; set; }
    public int PageCount { get; set; }
    public string Description { get; set; }
    public long LiteraryTypeId{ get; set; }
    public long PeriodId { get; set; }
    public long AuthorId { get; set; }
    
    public class Handler : IRequestHandler<CreateLiteraryCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateLiteraryCommand request, CancellationToken cancellationToken)
        {
            bool isLiteraryTypeIsExists = await _context.LiteraryTypes
                .AnyAsync(c => c.Id == request.LiteraryTypeId, cancellationToken);

            if (!isLiteraryTypeIsExists)
                throw new NotFoundException("Edebi tür bulunamadı.");

            bool isPeriodIsExists = await _context.Periods
                .AnyAsync(c => c.Id == request.PeriodId, cancellationToken);

            if (!isPeriodIsExists)
                throw new NotFoundException("Edebi dönem bulunamadı.");

            bool isAuthorExists = await _context.Authors
                .AnyAsync(c => c.Id == request.AuthorId, cancellationToken);

            if (!isAuthorExists)
                throw new NotFoundException("Yazar bulunamadı.");

            await _context.Literaries.AddAsync(new Literary
            {
                Name = request.Name,
                PageCount = request.PageCount,
                Description = request.Description,
                LiteraryTypeId = request.LiteraryTypeId,
                PeriodId = request.PeriodId,
                AuthorId = request.AuthorId
            });

            await _context.SaveChangesAsync(cancellationToken);
            
            return BaseResponseModel<Unit>.Success(Unit.Value,"Eser başarıyla eklendi.");
        }
    }
}