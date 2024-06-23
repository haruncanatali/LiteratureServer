using AutoMapper;
using LiteratureServer.Application.Common.Mappings;
using LiteratureServer.Domain.Entities;

namespace LiteratureServer.Application.Literaries.Queries.Dtos;

public class LiteraryPartialDto : IMapFrom<Literary>
{
    public long Id { get; set; }
    public long Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Literary, LiteraryPartialDto>();
    }
}