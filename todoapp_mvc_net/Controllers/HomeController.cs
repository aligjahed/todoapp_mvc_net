using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using todoapp_mvc_net.DB;
using todoapp_mvc_net.Models;
using todoapp_mvc_net.Services.TodoServices.Queries;


namespace todoapp_mvc_net.Controllers;

public class HomeController : Controller
{
    private readonly ISender _mediatr;
    private readonly UserManager<UserModel> _userManager;
    private readonly SignInManager<UserModel> _signInManager;

    public HomeController(ISender mediatr, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
    {
        _mediatr = mediatr;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> Index(int? sortBy)
    {
        if (!_signInManager.IsSignedIn(User))
        {
            return RedirectToPage("/Identity/Account/Login");
        }
        
        ViewData["sort"] = sortBy;
        var todos = await _mediatr.Send(new GetAllTodosQuery());

        switch (sortBy)
        {
            case 1:
                var todosDescending = from todo in todos
                    orderby todo.IsDone descending
                    select todo;
                todos = todosDescending.ToList();
                break;
            case 2:
                var todosAscending = from todo in todos
                    orderby todo.IsDone ascending 
                    select todo;
                todos = todosAscending.ToList();
                break;
            default:
                todos.Sort((x, y) => DateTime.Compare(x.CreatedAt, y.CreatedAt));
                break;
        }

        return View(todos);
    }
}