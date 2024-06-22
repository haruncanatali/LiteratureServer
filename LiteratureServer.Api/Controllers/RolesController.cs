using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.Roles.Commands.AddToRole;
using LiteratureServer.Application.Roles.Commands.Create;
using LiteratureServer.Application.Roles.Commands.Update;
using LiteratureServer.Application.Roles.Queries.Dtos;
using LiteratureServer.Application.Roles.Queries.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureServer.Api.Controllers;

public class RolesController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<List<RoleDto>>>> List([FromQuery]string? name)
    {
        return Ok(await Mediator.Send(new GetRolesQuery
        {
            Name = name
        }));
    }

    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Create(CreateRoleCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    [HttpPost]
    [Route("AddToRole")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> AddToRole(AddToRoleCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update([FromForm] UpdateRoleCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}