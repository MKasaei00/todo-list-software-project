using ToDoListWebApi.Models.Persistence;
using ToDoListWebApi.Models.StronglyTypedIds;

namespace ToDoListWebApi.Services.Abstractions;

public interface IAuthPersistenceService
{
    Task<bool> ValidateUser(Username username, string password);
    Task RegisterUser(Username username, string firstName, string lastName, string password);
    Task<PersistentUser> GetUser(Username username);
}