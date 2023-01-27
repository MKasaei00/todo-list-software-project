namespace ToDoListWebApi.Models.Domain;

public class ToDoListItem
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }
    public List<ToDoListItem> Children { get; set; }
}