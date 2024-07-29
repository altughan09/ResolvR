using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ResolvR.Application.Abstractions;

namespace ResolvR.Application.User;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor.HttpContext?.User;

        if (user is null)
        {
            throw new InvalidOperationException("User context not available");
        }

        if (user.Identity is null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var roles = user.FindAll(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

        return new CurrentUser(userId, email, roles);
    }
}