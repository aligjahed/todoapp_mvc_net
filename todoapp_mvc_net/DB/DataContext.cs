using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using todoapp_mvc_net.Models;

namespace todoapp_mvc_net.DB;

public class DataContext : IdentityDbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<UserModel> TodoAppUsers { get; set; }
    public DbSet<TodoModel> TodoAppTodos { get; set; }
}