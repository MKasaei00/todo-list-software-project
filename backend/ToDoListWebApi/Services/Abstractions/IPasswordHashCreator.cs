namespace ToDoListWebApi.Services.Abstractions;

public interface IPasswordHashCreator
{
    string Hash(string plainText);
}