using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.CommonValues.Queries.Dtos;
using MediatR;

namespace LiteratureServer.Application.CommonValues.Queries.GetGenders
{
    public class GetGendersQuery : IRequest<BaseResponseModel<List<KeyValueModel>>>
    {
    }
}
