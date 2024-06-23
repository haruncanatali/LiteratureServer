using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Entities;
using MediatR;

namespace LiteratureServer.Application.Periods.Commands.Create;

public class CreatePeriodCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public class Handler : IRequestHandler<CreatePeriodCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreatePeriodCommand request, CancellationToken cancellationToken)
        {
            await _context.Periods.AddAsync(new Period
            {
                Name = request.Name,
                Description = request.Description
            });

            await _context.SaveChangesAsync(cancellationToken);
            
            return BaseResponseModel<Unit>.Success(Unit.Value, "Dönem başarıyla eklendi.");
        }
    }
}