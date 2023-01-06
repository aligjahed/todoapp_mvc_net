using MediatR;

namespace todoapp_mvc_net.Services.TodoServices.Commands.RemoveTodo;

public class RemoveTodoCommand : IRequest
{
    public Guid Id { get; set; }
}