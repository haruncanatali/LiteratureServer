using LiteratureServer.Application.Periods.Queries.Dtos;

namespace LiteratureServer.Application.Periods.Queries.GetPeriods;

public class GetPeriodsVm
{
    public List<PeriodDto> Periods { get; set; }
    public long Count { get; set; }
}