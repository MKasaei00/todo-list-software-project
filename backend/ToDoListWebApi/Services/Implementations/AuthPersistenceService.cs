using Microsoft.EntityFrameworkCore;
using ToDoListWebApi.Models.Persistence;
using ToDoListWebApi.Models.StronglyTypedIds;
using ToDoListWebApi.Services.Abstractions;

namespace ToDoListWebApi.Services.Implementations;

public class AuthPersistenceService : IAuthPersistenceService
{
    private readonly DatabaseContext _dbContext;
    private readonly IPasswordHashCreator _passwordHashCreator;

    public AuthPersistenceService(DatabaseContext dbContext, IPasswordHashCreator passwordHashCreator)
    {
        _dbContext = dbContext;
        _passwordHashCreator = passwordHashCreator;
    }

    public async Task<bool> ValidateUser(Username username, string password)
    {
        var passwordHashValue = _passwordHashCreator.Hash(password);
        var usernameString = username.ToString();

        var foundUser = await _dbContext
            .Users
            .Where(user => user.Username == usernameString)
            .Where(user => user.HashedPassword == passwordHashValue)
            .SingleOrDefaultAsync();

        return foundUser is not null;
    }

    public async Task RegisterUser(Username username, string firstName, string lastName, string password)
    {
        var hash = _passwordHashCreator.Hash(password);
        
        _dbContext.Users.Add(new PersistentUser()
        {
            Username = username.ToString(),
            FirstName = firstName,
            LastName = lastName,
            HashedPassword = hash
        });
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task<PersistentUser> GetUser(Username username)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(user => user.Username == username.ToString());
        if (user is null)
        {
            throw new InvalidOperationException("User does not exists");
        }

        return user;
    }
}