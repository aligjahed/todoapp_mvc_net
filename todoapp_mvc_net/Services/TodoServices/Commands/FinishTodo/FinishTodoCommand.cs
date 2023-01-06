using MediatR;

namespace todoapp_mvc_net.Services.TodoServices.Commands.FinishTodo;

public class FinishTodoCommand : IRequest
{
    public Guid Id { get; set; }
}