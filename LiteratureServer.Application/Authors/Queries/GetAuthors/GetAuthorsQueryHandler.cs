using AutoMapper;
using AutoMapper.QueryableExtensions;
using LiteratureServer.Application.Authors.Queries.Dtos;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.Authors.Queries.GetAuthors;

public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, BaseResponseModel<GetAuthorsVm>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetAuthorsQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<GetAuthorsVm>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
        List<AuthorDto>? authors = await _context.Authors
            .Where(c => (request.FullName == null || c.FullName.ToLower().Contains(request.FullName.ToLower())))
            .Include(c => c.Literaries)
            .ThenInclude(c => c.Period)
            .Include(c => c.Literaries)
            .ThenInclude(c => c.LiteraryType)
            .ProjectTo<AuthorDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        return BaseResponseModel<GetAuthorsVm>.Success(new GetAuthorsVm
        {
            Authors = authors,
            Count = authors.Count
        });
    }
}