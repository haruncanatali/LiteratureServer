using LiteratureServer.Application.Authors.Commands.Create;
using LiteratureServer.Application.Authors.Commands.Delete;
using LiteratureServer.Application.Authors.Commands.Update;
using LiteratureServer.Application.Authors.Queries.GetAuthor;
using LiteratureServer.Application.Authors.Queries.GetAuthors;
using LiteratureServer.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureServer.Api.Controllers;

public class AuthorsController : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseModel<GetAuthorVm>>> GetById(long id = 0)
    {
        return Ok(await Mediator.Send(new GetAuthorQuery { Id = id }));
    }
    
    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<GetAuthorsVm>>> GetAll([FromQuery] GetAuthorsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create([FromForm] CreateAuthorCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update([FromForm] UpdateAuthorCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteAuthorCommand { AuthorId = id });
        return NoContent();
    }
}