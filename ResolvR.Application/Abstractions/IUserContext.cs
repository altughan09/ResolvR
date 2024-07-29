using ResolvR.Application.User;

namespace ResolvR.Application.Abstractions;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}