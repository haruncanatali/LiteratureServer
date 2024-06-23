using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.LiteraryTypes.Commands.Create;
using LiteratureServer.Application.LiteraryTypes.Commands.Delete;
using LiteratureServer.Application.LiteraryTypes.Commands.Update;
using LiteratureServer.Application.LiteraryTypes.Queries.GetLiteraryType;
using LiteratureServer.Application.LiteraryTypes.Queries.GetLiteraryTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureServer.Api.Controllers;

public class LiteraryTypesController : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseModel<GetLiteraryTypeVm>>> GetById(long id = 0)
    {
        return Ok(await Mediator.Send(new GetLiteraryTypeQuery { Id = id }));
    }
    
    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<GetLiteraryTypesVm>>> GetAll([FromQuery] GetLiteraryTypesQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create([FromForm] CreateLiteraryTypeCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update([FromForm] UpdateLiteraryTypeCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteLiteraryTypeCommand { Id = id });
        return NoContent();
    }
}