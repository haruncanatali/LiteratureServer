using LiteratureServer.Application.Common.Exceptions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.Literaries.Commands.Update;

public class UpdateLiteraryCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int PageCount { get; set; }
    public string Description { get; set; }
    public long LiteraryTypeId{ get; set; }
    public long PeriodId { get; set; }
    public long AuthorId { get; set; }
    
    public class Handler : IRequestHandler<UpdateLiteraryCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(UpdateLiteraryCommand request, CancellationToken cancellationToken)
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

            Literary? literary = await _context.Literaries
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            
            if(literary == null)
                throw new NotFoundException("Eser bulunamadı.");

            literary.Name = request.Name;
            literary.Description = request.Description;
            literary.PageCount = request.PageCount;
            literary.LiteraryTypeId = request.LiteraryTypeId;
            literary.PeriodId = request.PeriodId;
            literary.AuthorId = request.AuthorId;

            _context.Literaries.Update(literary);
            await _context.SaveChangesAsync(cancellationToken);
            
            return BaseResponseModel<Unit>.Success(Unit.Value, "Eser başarıyla güncellendi.");
        }
    }
}