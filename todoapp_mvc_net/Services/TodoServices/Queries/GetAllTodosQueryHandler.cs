using MediatR;
using todoapp_mvc_net.Models;
using todoapp_mvc_net.Services.Common;

namespace todoapp_mvc_net.Services.TodoServices.Queries;

public class GetAllTodosQueryHandler : IRequestHandler<GetAllTodosQuery , List<TodoModel>>
{
    private readonly TodoService _todoService;

    public GetAllTodosQueryHandler(TodoService todoService)
    {
        _todoService = todoService;
    }

    public async Task<List<TodoModel>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = await _todoService.GetAllTodo();
        return todos;
    }
}