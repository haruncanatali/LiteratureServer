using LiteratureServer.Application.Common.Models;
using MediatR;

namespace LiteratureServer.Application.Literaries.Queries.GetLiteraries;

public class GetLiterariesQuery : IRequest<BaseResponseModel<GetLiterariesVm>>
{
    public string? Name { get; set; }
    public long? Author { get; set; }
}