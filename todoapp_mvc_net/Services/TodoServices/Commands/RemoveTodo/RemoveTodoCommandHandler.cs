using MediatR;
using todoapp_mvc_net.Services.Common;

namespace todoapp_mvc_net.Services.TodoServices.Commands.RemoveTodo;

public class RemoveTodoCommandHandler : AsyncRequestHandler<RemoveTodoCommand>
{
    private readonly TodoService _todoService;

    public RemoveTodoCommandHandler(TodoService todoService)
    {
        _todoService = todoService;
    }

    protected override async Task Handle(RemoveTodoCommand request, CancellationToken cancellationToken)
    {
        if (request.Id != null)
        {
            await _todoService.RemoveTodo(request.Id);
        }
        else
        {
            throw new Exception("The id is not specified");
        }
    }
}