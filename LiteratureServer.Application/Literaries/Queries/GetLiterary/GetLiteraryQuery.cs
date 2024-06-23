using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.Literaries.Queries.Dtos;
using MediatR;

namespace LiteratureServer.Application.Literaries.Queries.GetLiterary;

public class GetLiteraryQuery : IRequest<BaseResponseModel<GetLiteraryVm>>
{
    public long Id { get; set; }
}