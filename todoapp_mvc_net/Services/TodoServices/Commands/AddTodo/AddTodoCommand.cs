using MediatR;

namespace todoapp_mvc_net.Services.TodoServices.Command;

public class AddTodoCommand : IRequest
{
    public string Title { get; set; }
}