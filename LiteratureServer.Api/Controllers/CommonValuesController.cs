using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.CommonValues.Queries.Dtos;
using LiteratureServer.Application.CommonValues.Queries.GetGenders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureServer.Api.Controllers
{
    public class CommonValuesController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("Genders")]
        public async Task<ActionResult<BaseResponseModel<KeyValueModel>>> GetGenders()
        {
            return Ok(await Mediator.Send(new GetGendersQuery()));
        }

    }
}
