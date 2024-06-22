using System.Runtime.Serialization;
using LiteratureServer.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace LiteratureServer.Domain.Identity;

public class User : IdentityUser<long>
{
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string ProfilePhoto { get; set; }
    public DateTime Birthdate { get; set; }
    public Gender Gender { get; set; }
    
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiredTime { get; set; }
    public string DeviceToken { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public long CreatedBy { get; set; }
    public long? UpdatedBy { get; set; }


    [IgnoreDataMember]
    public string FullName
    {
        get { return $"{FirstName} {Surname}"; }
    }
}