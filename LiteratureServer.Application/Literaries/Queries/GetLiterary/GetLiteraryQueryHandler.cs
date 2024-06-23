using AutoMapper;
using AutoMapper.QueryableExtensions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.Literaries.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.Literaries.Queries.GetLiterary;

public class GetLiteraryQueryHandler : IRequestHandler<GetLiteraryQuery, BaseResponseModel<GetLiteraryVm>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetLiteraryQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<GetLiteraryVm>> Handle(GetLiteraryQuery request, CancellationToken cancellationToken)
    {
        LiteraryDto? literary = await _context.Literaries
            .Where(c => c.Id == request.Id)
            .Include(c => c.Author)
            .Include(c => c.LiteraryType)
            .Include(c => c.Period)
            .ProjectTo<LiteraryDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        
        return BaseResponseModel<GetLiteraryVm>.Success(new GetLiteraryVm
        {
            Literary = literary
        }, "Eser başarıyla getirildi.");
    }
}