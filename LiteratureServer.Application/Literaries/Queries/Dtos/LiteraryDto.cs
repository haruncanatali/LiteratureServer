using AutoMapper;
using LiteratureServer.Application.Common.Mappings;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Entities;

namespace LiteratureServer.Application.Literaries.Queries.Dtos;

public class LiteraryDto : BaseDto, IMapFrom<Literary>
{
    public string Name { get; set; }
    public int PageCount { get; set; }
    public string Description { get; set; }

    public long LiteraryTypeId{ get; set; }
    public long PeriodId { get; set; }
    public long AuthorId { get; set; }

    public string AuthorFullName { get; set; }
    public string PeriodName { get; set; }
    public string LiteraryTypeName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Literary, LiteraryDto>()
            .ForMember(dest => dest.AuthorFullName, opt =>
                opt.MapFrom(c => c.Author.FullName))
            .ForMember(dest => dest.PeriodName, opt =>
                opt.MapFrom(c => c.Period.Name))
            .ForMember(dest => dest.LiteraryTypeName, opt =>
                opt.MapFrom(c => c.LiteraryType.Name));
    }
}