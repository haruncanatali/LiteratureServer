using AutoMapper;
using AutoMapper.QueryableExtensions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.Periods.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.Periods.Queries.GetPeriod;

public class GetPeriodQueryHandler : IRequestHandler<GetPeriodQuery, BaseResponseModel<GetPeriodVm>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetPeriodQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<GetPeriodVm>> Handle(GetPeriodQuery request, CancellationToken cancellationToken)
    {
        PeriodDto? period = await _context.Periods
            .Where(c => c.Id == request.Id)
            .Include(c => c.Literaries)
            .ProjectTo<PeriodDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        
        return BaseResponseModel<GetPeriodVm>.Success(new GetPeriodVm
        {
            Period = period
        }, "Dönem başarıyla çekildi.");
    }
}