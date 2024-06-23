using LiteratureServer.Application.Common.Models;
using MediatR;

namespace LiteratureServer.Application.Authors.Queries.GetAuthors;

public class GetAuthorsQuery : IRequest<BaseResponseModel<GetAuthorsVm>>
{
    public string? FullName { get; set; }
}