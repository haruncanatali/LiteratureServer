using LiteratureServer.Application.Common.Models;
using MediatR;

namespace LiteratureServer.Application.LiteraryTypes.Queries.GetLiteraryTypes;

public class GetLiteraryTypesQuery : IRequest<BaseResponseModel<GetLiteraryTypesVm>>
{
    public string? Name { get; set; }
}