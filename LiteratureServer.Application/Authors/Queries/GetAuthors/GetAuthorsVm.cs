using LiteratureServer.Application.Authors.Queries.Dtos;

namespace LiteratureServer.Application.Authors.Queries.GetAuthors;

public class GetAuthorsVm
{
    public List<AuthorDto> Authors { get; set; }
    public long Count { get; set; }
}