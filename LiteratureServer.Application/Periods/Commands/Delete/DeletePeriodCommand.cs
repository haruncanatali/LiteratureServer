using LiteratureServer.Application.Common.Exceptions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.Periods.Commands.Delete;

public class DeletePeriodCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeletePeriodCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;
        
        public async Task<BaseResponseModel<Unit>> Handle(DeletePeriodCommand request, CancellationToken cancellationToken)
        {
            Period? period = await _context.Periods.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (period is null)
                throw new NotFoundException("Dönem bulunamadı.");

            _context.Periods.Remove(period);
            await _context.SaveChangesAsync(cancellationToken);
            
            return BaseResponseModel<Unit>.Success(Unit.Value, "Dönem başarıyla silindi.");
        }
    }
}