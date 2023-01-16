using ToDoListWebApi.Models.Persistence;
using ToDoListWebApi.Models.StronglyTypedIds;
using ToDoListWebApi.Services.Abstractions;

namespace ToDoListWebApi.Services.Implementations;

public class AuthService : IAuthService
{
    private const string TokenCookieName = "Auth-Token";
    private readonly IAuthPersistenceService _authPersistenceService;
    private readonly IActiveUsers _activeUsers;

    public AuthService(IAuthPersistenceService authPersistenceService, IActiveUsers activeUsers)
    {
        _authPersistenceService = authPersistenceService;
        _activeUsers = activeUsers;
    }

    public async Task Login(Username username,
        string password,
        IRequestCookieCollection requestCookieCollection,
        IResponseCookies responseCookies
    )
    {
        var isUserValid = await _authPersistenceService.ValidateUser(username, password);
        if (isUserValid) 
        {
            ChangeToUser(username, responseCookies);
        }
        else
        {
            throw new InvalidOperationException("invalid user");
        }
    }

    public async Task Logout(IResponseCookies responseCookies)
    {
        responseCookies.Delete(TokenCookieName);
    }

    public Task<PersistentUser> GetInfo(IRequestCookieCollection requestCookieCollection)
    {
        requestCookieCollection.TryGetValue(TokenCookieName, out var cookieValue);
        if (cookieValue is null)
        {
            throw new InvalidOperationException("Not logged in");
        }

        var token = new Token(Guid.Parse(cookieValue));

        var currentUser = _activeUsers.Get(token);
        return _authPersistenceService.GetUser(currentUser);
    }

    public async Task Register(
        Username username,
        string firstName,
        string lastName,
        string password,
        IResponseCookies responseCookies
    )
    {
        await _authPersistenceService.RegisterUser(username, firstName, lastName, password);
        ChangeToUser(username, responseCookies);
    }

    private void ChangeToUser(Username username,
        IResponseCookies responseCookies)
    {
        var token = _activeUsers.Add(username);
        responseCookies.Append(TokenCookieName, token.ToString());
    }
}