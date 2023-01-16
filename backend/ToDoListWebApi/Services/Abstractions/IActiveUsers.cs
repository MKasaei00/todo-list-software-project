using ToDoListWebApi.Models.StronglyTypedIds;

namespace ToDoListWebApi.Services.Abstractions;

public interface IActiveUsers
{
    Token Add(Username username);
    Username Get(Token token);
    void Delete(Username username);
}