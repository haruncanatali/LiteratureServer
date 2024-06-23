using LiteratureServer.Application.Common.Models;
using MediatR;

namespace LiteratureServer.Application.LiteraryTypes.Queries.GetLiteraryType;

public class GetLiteraryTypeQuery : IRequest<BaseResponseModel<GetLiteraryTypeVm>>
{
    public long Id { get; set; }
}