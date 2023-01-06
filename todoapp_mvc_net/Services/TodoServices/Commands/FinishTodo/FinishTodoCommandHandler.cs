using MediatR;
using todoapp_mvc_net.Services.Common;

namespace todoapp_mvc_net.Services.TodoServices.Commands.FinishTodo;

public class FinishTodoCommandHandler : AsyncRequestHandler<FinishTodoCommand>
{
    private readonly TodoService _todoService;

    public FinishTodoCommandHandler(TodoService todoService)
    {
        _todoService = todoService;
    }

    protected override async Task Handle(FinishTodoCommand request, CancellationToken cancellationToken)
    {
        if (request.Id != null)
        {
            await _todoService.FinishTodo(request.Id);
        }
        else
        {
            throw new Exception("No id is specified");
        }
    }
}