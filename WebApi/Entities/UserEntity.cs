using Microsoft.AspNetCore.Identity;

namespace WebApi.Entities;

public class UserEntity : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public bool Verified { get; set; }
}
