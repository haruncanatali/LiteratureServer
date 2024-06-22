using Microsoft.AspNetCore.Identity;

namespace LiteratureServer.Domain.Identity;

public class UserRole : IdentityUserRole<long>
{
    public UserRole() : base()
    {
            
    }
}