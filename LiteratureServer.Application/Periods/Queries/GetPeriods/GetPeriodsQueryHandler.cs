using AutoMapper;
using AutoMapper.QueryableExtensions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.Periods.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.Periods.Queries.GetPeriods;

public class GetPeriodsQueryHandler : IRequestHandler<GetPeriodsQuery, BaseResponseModel<GetPeriodsVm>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetPeriodsQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<GetPeriodsVm>> Handle(GetPeriodsQuery request, CancellationToken cancellationToken)
    {
        List<PeriodDto> periods = await _context.Periods
            .Where(c => (request.Name == null || c.Name.ToLower().Contains(request.Name.ToLower())))
            .Include(c => c.Literaries)
            .ProjectTo<PeriodDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        return BaseResponseModel<GetPeriodsVm>.Success(new GetPeriodsVm
        {
            Periods = periods,
            Count = periods.Count
        }, "Edebi dönemler başarıyla çekildi."); 
    }
}