using AutoMapper;
using LiteratureServer.Application.Common.Mappings;
using LiteratureServer.Domain.Entities;

namespace LiteratureServer.Application.Literaries.Queries.Dtos;

public class LiteraryForAuthorDto : IMapFrom<Literary>
{
    public long Id { get; set; }
    public long PeriodId { get; set; }
    public long LiteraryTypeId { get; set; }
    
    public string Name { get; set; }
    public string PeriodName { get; set; }
    public string LiteraryTypeName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Literary, LiteraryForAuthorDto>()
            .ForMember(dest => dest.PeriodId, opt =>
                opt.MapFrom(c => c.Period.Id))
            .ForMember(dest => dest.LiteraryTypeId, opt =>
                opt.MapFrom(c => c.LiteraryType.Id))
            .ForMember(dest => dest.PeriodName, opt =>
                opt.MapFrom(c => c.Period.Name))
            .ForMember(dest => dest.LiteraryTypeName, opt =>
                opt.MapFrom(c => c.LiteraryType.Name));
    }
}