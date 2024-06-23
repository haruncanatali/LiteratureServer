using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.Literaries.Commands.Create;
using LiteratureServer.Application.Literaries.Commands.Delete;
using LiteratureServer.Application.Literaries.Commands.Update;
using LiteratureServer.Application.Literaries.Queries.GetLiteraries;
using LiteratureServer.Application.Literaries.Queries.GetLiterary;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureServer.Api.Controllers;

public class LiterariesController : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseModel<GetLiteraryVm>>> GetById(long id = 0)
    {
        return Ok(await Mediator.Send(new GetLiteraryQuery() { Id = id }));
    }
    
    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<GetLiterariesVm>>> GetAll([FromQuery] GetLiterariesQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create([FromForm] CreateLiteraryCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update([FromForm] UpdateLiteraryCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteLiteraryCommand { Id = id });
        return NoContent();
    }
}