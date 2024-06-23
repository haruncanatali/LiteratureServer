using AutoMapper;
using LiteratureServer.Application.Common.Mappings;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.Literaries.Queries.Dtos;
using LiteratureServer.Domain.Entities;

namespace LiteratureServer.Application.Periods.Queries.Dtos;

public class PeriodDto : BaseDto, IMapFrom<Period>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<LiteraryPartialDto> Literaries { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Period, PeriodDto>()
            .ForMember(dest => dest.Literaries, opt =>
                opt.MapFrom(c => c.Literaries));
    }
}