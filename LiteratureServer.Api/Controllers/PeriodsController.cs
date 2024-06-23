using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.Periods.Commands.Create;
using LiteratureServer.Application.Periods.Commands.Delete;
using LiteratureServer.Application.Periods.Commands.Update;
using LiteratureServer.Application.Periods.Queries.GetPeriod;
using LiteratureServer.Application.Periods.Queries.GetPeriods;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureServer.Api.Controllers;

public class PeriodsController : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseModel<GetPeriodVm>>> GetById(long id = 0)
    {
        return Ok(await Mediator.Send(new GetPeriodQuery { Id = id }));
    }
    
    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<GetPeriodsVm>>> GetAll([FromQuery] GetPeriodsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create([FromForm] CreatePeriodCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update([FromForm] UpdatePeriodCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeletePeriodCommand { Id = id });
        return NoContent();
    }
}