using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.Roles.Queries.Dtos;
using MediatR;

namespace LiteratureServer.Application.Roles.Queries.GetRoles;

public class GetRolesQuery : IRequest<BaseResponseModel<List<RoleDto>>>
{
    public string? Name { get; set; }
}