using System.ComponentModel.DataAnnotations;

namespace ToDoListWebApi.Models.Persistence;

public class PersistentUser
{
    [Key] public string Username { get; set; }
    public string HashedPassword { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
}