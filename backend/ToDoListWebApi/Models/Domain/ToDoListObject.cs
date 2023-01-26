using ToDoListWebApi.Models.StronglyTypedIds;

namespace ToDoListWebApi.Models.Domain;

public class ToDoListObject
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string OwnerUsername { get; set; }
    public List<string> ValidUsers { get; set; }
    public List<ToDoListItem> Items { get; set; } 
}