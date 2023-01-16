using ToDoListWebApi.Models.StronglyTypedIds;
using ToDoListWebApi.Services.Abstractions;

namespace ToDoListWebApi.Services.Implementations;

public class ActiveUsers : IActiveUsers
{
    private readonly Dictionary<Token, Username> _usernameByToken = new();
    private readonly Dictionary<Username, Token> _tokenByUsername = new();

    public Token Add(Username username)
    {
        if (_tokenByUsername.TryGetValue(username, out var preToken))
        {
            _tokenByUsername.Remove(username);
            _usernameByToken.Remove(preToken);
        }

        var token = Token.New();
        _tokenByUsername.Add(username, token);
        _usernameByToken.Add(token, username);

        return token;
    }

    public Username Get(Token token)
    {
        var exists = _usernameByToken.TryGetValue(token, out var username);
        if (exists)
        {
            return username;
        }

        throw new InvalidOperationException("Token is not valid");
    }

    public void Delete(Username username)
    {
        var hasToken = _tokenByUsername.TryGetValue(username, out var token);
        if (!hasToken)
        {
            throw new InvalidOperationException("User is not logged in");
        }

        _tokenByUsername.Remove(username);
        _usernameByToken.Remove(token);
    }
}