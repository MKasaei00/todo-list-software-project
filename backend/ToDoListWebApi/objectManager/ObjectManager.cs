using Microsoft.EntityFrameworkCore;
using ToDoListWebApi.Adapter;
using ToDoListWebApi.Models.Domain;
using ToDoListWebApi.Models.StronglyTypedIds;
using ToDoListWebApi.Services.Implementations;

namespace ToDoListWebApi.objectManager;

public class ObjectManager
{
    private readonly DatabaseContext _databaseContext;
    private readonly ToDoListObjectAdapter _toDoListObjectAdapter;

    public ObjectManager(DatabaseContext databaseContext, ToDoListObjectAdapter toDoListObjectAdapter)
    {
        _databaseContext = databaseContext;
        _toDoListObjectAdapter = toDoListObjectAdapter;
    }

    public List<ToDoListObject> LoadAllObjects()
    {
        var objects = _databaseContext.ToDoListObjects.ToList();
        var models = objects.Select(o => _toDoListObjectAdapter.ConvertModel(o)).ToList();
        return models;
    }

    public List<ToDoListObject> LoadObjects(string username)
    {
        var models = LoadAllObjects();
        var result = models.Where(o => o.OwnerUsername == username).ToList();

        return result;
    }

    public List<ToDoListObject> LoadVisibleObjects(string username)
    {
        var models = LoadAllObjects();
        var result = models.Where(o => o.ValidUsers.Contains(username)).ToList();

        return result;
    }

    public async Task Create(string username, ToDoListObject listObject)
    {
        listObject.OwnerUsername = username;

        var persistentToDoListObject = _toDoListObjectAdapter.ConvertPersistent(listObject);

        await _databaseContext.ToDoListObjects.AddAsync(persistentToDoListObject);
        await _databaseContext.SaveChangesAsync();
    }
    
    public async Task Update(string infoUsername, ToDoListObject listObject)
    {
        var newObj = _toDoListObjectAdapter.ConvertPersistent(listObject);

        var oldObj = await _databaseContext.ToDoListObjects.SingleOrDefaultAsync(o => o.Id == listObject.Id);

        if (oldObj is null)
        {
            throw new InvalidOperationException("Could not find item with this id");
        }

        var oldObjModel = _toDoListObjectAdapter.ConvertModel(oldObj);

        if (!oldObjModel.ValidUsers.Contains(infoUsername))
        {
            throw new InvalidOperationException("User has no access to this list");
        }
        
        oldObj.Content = newObj.Content;
        
        await _databaseContext.SaveChangesAsync();
    }
    
    public async Task Delete(int id)
    {
        var item = _databaseContext.ToDoListObjects.SingleOrDefault(o => o.Id == id);

        if (item is null)
        {
            throw new InvalidOperationException("Could not find the item inside list");
        }

        _databaseContext.ToDoListObjects.Remove(item);
        
        await _databaseContext.SaveChangesAsync();
    }
}