using LiteratureServer.Application.Common.Models;
using MediatR;

namespace LiteratureServer.Application.Periods.Queries.GetPeriods;

public class GetPeriodsQuery : IRequest<BaseResponseModel<GetPeriodsVm>>
{
    public string? Name { get; set; }
}