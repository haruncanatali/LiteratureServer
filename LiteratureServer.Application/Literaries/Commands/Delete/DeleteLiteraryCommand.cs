using LiteratureServer.Application.Common.Exceptions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.Literaries.Commands.Delete;

public class DeleteLiteraryCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteLiteraryCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeleteLiteraryCommand request, CancellationToken cancellationToken)
        {
            Literary? literary = await _context.Literaries
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (literary == null)
                throw new NotFoundException("Edebi eser bulunamadı.");

            _context.Literaries.Remove(literary);
            await _context.SaveChangesAsync(cancellationToken);
            
            return BaseResponseModel<Unit>.Success(Unit.Value, "Edebi eser başarıyla silindi.");
        }
    }
}