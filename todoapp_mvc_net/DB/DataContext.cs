using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using todoapp_mvc_net.Models;

namespace todoapp_mvc_net.DB;

public class DataContext : IdentityDbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder
            //.UseSqlServer("server=localhost\\SQLEXPRESS;Database=tododb;Trusted_Connection=true;TrustServerCertificate=true;");
            .UseSqlServer("server=localhost;Database=tododb;Trusted_Connection=true;TrustServerCertificate=true;");
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<TodoModel> Todos { get; set; }
}