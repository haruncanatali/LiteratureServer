using LiteratureServer.Application.Common.Models;
using MediatR;

namespace LiteratureServer.Application.Authors.Queries.GetAuthor;

public class GetAuthorQuery : IRequest<BaseResponseModel<GetAuthorVm>>
{
    public long Id { get; set; }
}