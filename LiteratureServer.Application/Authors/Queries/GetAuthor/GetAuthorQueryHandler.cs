using AutoMapper;
using AutoMapper.QueryableExtensions;
using LiteratureServer.Application.Authors.Queries.Dtos;
using LiteratureServer.Application.Common.Exceptions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.Authors.Queries.GetAuthor;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, BaseResponseModel<GetAuthorVm>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetAuthorQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<GetAuthorVm>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        AuthorDto? author = await _context.Authors
            .Where(c => c.Id == request.Id)
            .Include(c => c.Literaries)
            .ThenInclude(c => c.Period)
            .Include(c => c.Literaries)
            .ThenInclude(c => c.LiteraryType)
            .ProjectTo<AuthorDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (author == null)
        {
            throw new NotFoundException("Yazar bulunamadı");
        }
        
        return BaseResponseModel<GetAuthorVm>.Success(new GetAuthorVm
        {
            Author = author
        }, "Yazar başarıyla getirildi.");
    }
}