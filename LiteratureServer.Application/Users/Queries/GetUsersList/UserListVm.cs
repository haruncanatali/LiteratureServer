using LiteratureServer.Application.Users.Queries.GetUserDetail;

namespace LiteratureServer.Application.Users.Queries.GetUsersList;

public class UserListVm
{
    public IList<UserDetailDto> Users { get; set; }

    public int Count { get; set; }
}