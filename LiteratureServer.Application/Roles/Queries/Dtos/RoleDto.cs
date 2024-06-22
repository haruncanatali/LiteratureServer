using AutoMapper;
using LiteratureServer.Application.Common.Mappings;
using LiteratureServer.Domain.Identity;

namespace LiteratureServer.Application.Roles.Queries.Dtos;

public class RoleDto : IMapFrom<Role>
{
    public long Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Role, RoleDto>();
    }
}