using LiteratureServer.Application.LiteraryTypes.Queries.Dtos;

namespace LiteratureServer.Application.LiteraryTypes.Queries.GetLiteraryTypes;

public class GetLiteraryTypesVm
{
    public List<LiteraryTypeDto> LiteraryTypes { get; set; }
    public long Count { get; set; }
}