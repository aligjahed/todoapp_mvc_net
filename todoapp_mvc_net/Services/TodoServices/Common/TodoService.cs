using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using todoapp_mvc_net.DB;
using todoapp_mvc_net.Models;
using System.Security.Claims;


namespace todoapp_mvc_net.Services.Common;

public class TodoService
{
    private readonly DataContext _context;
    private readonly SignInManager<UserModel> _signInManager;
    private readonly UserManager<UserModel> _userManager;

    public TodoService(DataContext context, SignInManager<UserModel> signInManager, UserManager<UserModel> userManager)
    {
        _context = context;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<List<TodoModel>> GetAllTodo()
    {
        var userID = _signInManager.Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _context.TodoAppUsers
            .Include(x => x.Todos)
            .FirstOrDefaultAsync(x => x.Id == userID);
        return user.Todos;
    }

    public async Task AddTodo(string title)
    {
        var userID = _signInManager.Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var todo = new TodoModel
            { Id = Guid.NewGuid(), Title = title, User = await _userManager.FindByIdAsync(userID) };
        await _context.TodoAppTodos.AddAsync(todo);
        await _context.SaveChangesAsync();
    }

    public async Task FinishTodo(Guid reqId)
    {
        var userID = _signInManager.Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var reqTodo = await _context.TodoAppTodos
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == reqId);
        if (reqTodo.User.Id == userID)
        {
            reqTodo.IsDone = true;
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("You're not allowed to make change to this entity.");
        }
    }

    public async Task RemoveTodo(Guid reqId)
    {
        var userID = _signInManager.Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var reqTodo = await _context.TodoAppTodos
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == reqId);
        if (reqTodo.User.Id == userID)
        {
            _context.TodoAppTodos.Remove(reqTodo);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("You're not allowed to make change to this entity.");
        }
    }
}