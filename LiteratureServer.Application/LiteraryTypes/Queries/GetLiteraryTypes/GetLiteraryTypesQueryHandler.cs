using AutoMapper;
using AutoMapper.QueryableExtensions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.LiteraryTypes.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.LiteraryTypes.Queries.GetLiteraryTypes;

public class GetLiteraryTypesQueryHandler : IRequestHandler<GetLiteraryTypesQuery, BaseResponseModel<GetLiteraryTypesVm>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetLiteraryTypesQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<GetLiteraryTypesVm>> Handle(GetLiteraryTypesQuery request, CancellationToken cancellationToken)
    {
        List<LiteraryTypeDto>? literaryTypes = await _context.LiteraryTypes
            .Where(c => (request.Name == null || c.Name.ToLower().Contains(request.Name.ToLower())))
            .Include(c => c.Literaries)
            .ProjectTo<LiteraryTypeDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        return BaseResponseModel<GetLiteraryTypesVm>.Success(new GetLiteraryTypesVm
        {
            LiteraryTypes = literaryTypes,
            Count = literaryTypes.Count
        }, "Edebi türler başarıyla çekildi.");
    }
}