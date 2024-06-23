using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Entities;
using MediatR;

namespace LiteratureServer.Application.LiteraryTypes.Commands.Create;

public class CreateLiteraryTypeCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public class Handler : IRequestHandler<CreateLiteraryTypeCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateLiteraryTypeCommand request, CancellationToken cancellationToken)
        {
            await _context.LiteraryTypes.AddAsync(new LiteraryType
            {   
                Name = request.Name,
                Description = request.Description
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            
            return BaseResponseModel<Unit>.Success(Unit.Value, "Edebi tür başarıyla eklendi.");
        }
    }
}