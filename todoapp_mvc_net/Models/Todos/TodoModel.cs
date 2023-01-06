namespace todoapp_mvc_net.Models;

public class TodoModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool IsDone { get; set; } = false;
    public DateTime CreatedAt { get; set; }= DateTime.Now;
}