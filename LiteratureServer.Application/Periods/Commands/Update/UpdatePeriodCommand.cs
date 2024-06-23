using LiteratureServer.Application.Common.Exceptions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.Periods.Commands.Update;

public class UpdatePeriodCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public class Handler : IRequestHandler<UpdatePeriodCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(UpdatePeriodCommand request, CancellationToken cancellationToken)
        {
            Period? period = await _context.Periods.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (period is null)
                throw new NotFoundException("Dönem bulunamadı.");

            period.Name = request.Name;
            period.Description = request.Description;

            _context.Periods.Update(period);
            await _context.SaveChangesAsync(cancellationToken);
            
            return BaseResponseModel<Unit>.Success(Unit.Value, "Dönem başarıyla güncellendi.");
        }
    }
}