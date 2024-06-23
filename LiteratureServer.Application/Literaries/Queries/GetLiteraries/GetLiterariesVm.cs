using LiteratureServer.Application.Literaries.Queries.Dtos;

namespace LiteratureServer.Application.Literaries.Queries.GetLiteraries;

public class GetLiterariesVm
{
    public List<LiteraryDto> Literaries { get; set; }
    public long Count { get; set; }
}