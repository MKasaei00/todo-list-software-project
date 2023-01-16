using ToDoListWebApi.Models.Persistence;
using ToDoListWebApi.Models.StronglyTypedIds;

namespace ToDoListWebApi.Services.Abstractions;

public interface IAuthService
{
    Task Login(Username username,
        string password,
        IRequestCookieCollection requestCookieCollection,
        IResponseCookies responseCookies
    );

    Task Logout(IResponseCookies responseCookies);
    Task<PersistentUser> GetInfo(IRequestCookieCollection requestCookieCollection);

    Task Register(Username username,
        string firstName,
        string lastName,
        string password,
        IResponseCookies responseCookies);
}