using LiteratureServer.Application.Common.Models;
using MediatR;

namespace LiteratureServer.Application.Periods.Queries.GetPeriod;

public class GetPeriodQuery : IRequest<BaseResponseModel<GetPeriodVm>>
{
    public long Id { get; set; }
}