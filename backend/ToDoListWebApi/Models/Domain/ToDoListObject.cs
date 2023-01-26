using ToDoListWebApi.Models.StronglyTypedIds;

namespace ToDoListWebApi.Models.Domain;

public class ToDoListObject
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Username OwnerUsername { get; set; }
    public List<Username> ValidUsers { get; set; }
    public List<ToDoListItem> Items { get; set; } 
}