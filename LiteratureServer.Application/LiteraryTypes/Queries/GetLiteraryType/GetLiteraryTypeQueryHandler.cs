using AutoMapper;
using AutoMapper.QueryableExtensions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.LiteraryTypes.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.LiteraryTypes.Queries.GetLiteraryType;

public class GetLiteraryTypeQueryHandler : IRequestHandler<GetLiteraryTypeQuery, BaseResponseModel<GetLiteraryTypeVm>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetLiteraryTypeQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<GetLiteraryTypeVm>> Handle(GetLiteraryTypeQuery request, CancellationToken cancellationToken)
    {
        LiteraryTypeDto? literaryType = await _context.LiteraryTypes
            .Where(c => c.Id == request.Id)
            .Include(c => c.Literaries)
            .ProjectTo<LiteraryTypeDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        
        return BaseResponseModel<GetLiteraryTypeVm>.Success(new GetLiteraryTypeVm
        {
            LiteraryType = literaryType
        }, "Edebi tür başarıyla getirildi.");
    }
}