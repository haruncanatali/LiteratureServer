using AutoMapper;
using AutoMapper.QueryableExtensions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.Literaries.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.Literaries.Queries.GetLiteraries;

public class GetLiterariesQueryHandler : IRequestHandler<GetLiterariesQuery, BaseResponseModel<GetLiterariesVm>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetLiterariesQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<GetLiterariesVm>> Handle(GetLiterariesQuery request, CancellationToken cancellationToken)
    {
        List<LiteraryDto> literaries = await _context.Literaries
            .Where(c =>
                (request.Name == null || c.Name.ToLower().Contains(c.Name.ToLower())) &&
                (request.Author == null || c.AuthorId == request.Author))
            .Include(c => c.Author)
            .Include(c => c.LiteraryType)
            .Include(c => c.Period)
            .ProjectTo<LiteraryDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return BaseResponseModel<GetLiterariesVm>.Success(new GetLiterariesVm
        {
            Literaries = literaries,
            Count = literaries.Count
        }, "Eserler başarıyla getirildi.");
    }
}