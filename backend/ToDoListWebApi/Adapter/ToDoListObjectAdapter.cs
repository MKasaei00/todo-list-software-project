using ToDoListWebApi.Models.Domain;
using ToDoListWebApi.Models.Persistence;
using System.Text.Json;

namespace ToDoListWebApi.Adapter;

public class ToDoListObjectAdapter
{
    public ToDoListObject ConvertModel(PersistentToDoListObject persistentToDoListObject)
    {
        var obj = JsonSerializer.Deserialize<ToDoListObject>(persistentToDoListObject.Content);

        if (obj is null)
        {
            throw new InvalidOperationException("Could deserializer");
        }
        
        obj.Id = persistentToDoListObject.Id;
        return obj;
    }

    public PersistentToDoListObject ConvertPersistent(ToDoListObject obj)
    {
        return new PersistentToDoListObject()
        {
            Id = obj.Id,
            Content = JsonSerializer.Serialize(obj)
        };
    }
}