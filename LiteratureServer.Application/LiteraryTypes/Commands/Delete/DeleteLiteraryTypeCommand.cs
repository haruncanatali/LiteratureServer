using LiteratureServer.Application.Common.Exceptions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.LiteraryTypes.Commands.Delete;

public class DeleteLiteraryTypeCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteLiteraryTypeCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeleteLiteraryTypeCommand request, CancellationToken cancellationToken)
        {
            LiteraryType? literaryType = await _context.LiteraryTypes
                .Include(c=>c.Literaries)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (literaryType is null)
                throw new NotFoundException("Edebi tür bulunamadı.");

            if (literaryType.Literaries is { Count: > 0 })
            {
                _context.Literaries.RemoveRange(literaryType.Literaries);
                await _context.SaveChangesAsync(cancellationToken);
            }
            _context.LiteraryTypes.Remove(literaryType);
            await _context.SaveChangesAsync(cancellationToken);
            
            return BaseResponseModel<Unit>.Success(Unit.Value, "Edebi tür başarıyla silindi.");
        }
    }
}