using LiteratureServer.Application.Common.Exceptions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.LiteraryTypes.Commands.Update;

public class UpdateLiteraryTypeCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public class Handler : IRequestHandler<UpdateLiteraryTypeCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(UpdateLiteraryTypeCommand request, CancellationToken cancellationToken)
        {
            LiteraryType? literaryType = await _context.LiteraryTypes
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (literaryType is null)
                throw new NotFoundException("Edebi tür bulunamadı.");

            literaryType.Name = request.Name;
            literaryType.Description = request.Description;

            _context.LiteraryTypes.Update(literaryType);
            await _context.SaveChangesAsync(cancellationToken);
            
            return BaseResponseModel<Unit>.Success(Unit.Value, "Edebi tür başarıyla güncellendi.");
        }
    }
}