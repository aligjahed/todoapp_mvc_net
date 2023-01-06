namespace todoapp_mvc_net.Models;

public class TodoListModel
{
    public Guid id { get; set; }
    public string Name { get; set; }
    public virtual List<TodoModel> Todos { get; set; }
}