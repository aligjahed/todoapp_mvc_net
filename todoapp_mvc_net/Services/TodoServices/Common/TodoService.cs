using Microsoft.EntityFrameworkCore;
using todoapp_mvc_net.DB;
using todoapp_mvc_net.Models;

namespace todoapp_mvc_net.Services.Common;

public class TodoService
{
    private readonly DataContext _context;

    public TodoService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<TodoModel>> GetAllTodo()
    {
        var todos = await _context.Todos.ToListAsync();
        return todos;
    }
    
    public async Task AddTodo(string title)
    {
        var todo = new TodoModel { Id = Guid.NewGuid(), Title = title };
        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
    }

    public async Task FinishTodo(Guid reqId)
    {
        var reqTodo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == reqId);
        reqTodo.IsDone = true;
        await _context.SaveChangesAsync();
    }

    public async Task RemoveTodo(Guid reqId)
    {
        var reqTodo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == reqId);
        _context.Remove(reqTodo);
        await _context.SaveChangesAsync();
    }

}