using Microsoft.AspNetCore.Identity;

namespace todoapp_mvc_net.Models;

public class UserModel : IdentityUser
{
    public virtual List<TodoModel> Todos { get; set; }
}