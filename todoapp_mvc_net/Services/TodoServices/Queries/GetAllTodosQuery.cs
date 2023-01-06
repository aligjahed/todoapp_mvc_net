using MediatR;
using todoapp_mvc_net.Models;

namespace todoapp_mvc_net.Services.TodoServices.Queries;

public class GetAllTodosQuery : IRequest<List<TodoModel>>
{
    
}