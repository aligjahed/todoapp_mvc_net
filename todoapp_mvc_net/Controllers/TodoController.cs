using MediatR;
using Microsoft.AspNetCore.Mvc;
using todoapp_mvc_net.DB;
using todoapp_mvc_net.Models;
using todoapp_mvc_net.Services.TodoServices.Command;
using todoapp_mvc_net.Services.TodoServices.Commands.FinishTodo;
using todoapp_mvc_net.Services.TodoServices.Commands.RemoveTodo;

namespace todoapp_mvc_net.Controllers;

public class TodoController : Controller
{
    private readonly ISender _mediatr;

    public TodoController(ISender mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost]
    public async Task<IActionResult> Add(string todo)
    {
        await _mediatr.Send(new AddTodoCommand{Title = todo});
        return Redirect(Url.Action("Index" , "Home"));
    }

    public async Task<IActionResult> Finish(Guid id , int? sortBy)
    {
        await _mediatr.Send(new FinishTodoCommand{Id = id});
        return Redirect(Url.Action("Index", "Home" , new {sortBy = sortBy}));
    }

    public async Task<IActionResult> Remove(Guid id , int? sortBy)
    {
        await _mediatr.Send(new RemoveTodoCommand() { Id = id });
        return Redirect(Url.Action("Index" , "Home" , new {sortBy = sortBy}));
    }
}