using System.Security.Cryptography;
using System.Text;
using ToDoListWebApi.Services.Abstractions;

namespace ToDoListWebApi.Services.Implementations;

public class PasswordHashCreator : IPasswordHashCreator
{
    public string Hash(string plainText)
    {
        return HashBytes(Encoding.UTF8.GetBytes(plainText));
    }

    private static string HashBytes(byte[] bytes)
    {
        var hash = SHA1.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
}