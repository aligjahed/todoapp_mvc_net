using MediatR;
using todoapp_mvc_net.Services.Common;

namespace todoapp_mvc_net.Services.TodoServices.Command;

public class AddTodoCommandHandler : AsyncRequestHandler<AddTodoCommand>
{
    private readonly TodoService _todoService;

    public AddTodoCommandHandler(TodoService todoService)
    {
        _todoService = todoService;
    }

    protected override async Task Handle(AddTodoCommand request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(request.Title))
        {
            await _todoService.AddTodo(request.Title);
        }
        else
        {
            throw new Exception("Title is null");
        }
    }
}