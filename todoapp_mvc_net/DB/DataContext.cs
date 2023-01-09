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

        // only for dev
        // var connectionStr = "Server=localhost;Database=tododb;Uid=root;Pwd=Ali.958918;";
        // optionsBuilder
        //     //.UseSqlServer("server=localhost\\SQLEXPRESS;Database=tododb;Trusted_Connection=true;TrustServerCertificate=true;");
        //     //.UseSqlServer("server=localhost;Database=tododb;Trusted_Connection=true;TrustServerCertificate=true;");
        //     .UseMySql(connectionStr , ServerVersion.AutoDetect(connectionStr));

        // production
        var MYSQLDATABASE = Environment.GetEnvironmentVariable("MYSQLDATABASE");
        var MYSQLHOST = Environment.GetEnvironmentVariable("MYSQLHOST");
        var MYSQLPASSWORD = Environment.GetEnvironmentVariable("MYSQLPASSWORD");
        var MYSQLPORT = Environment.GetEnvironmentVariable("MYSQLPORT");
        var MYSQLUSER = Environment.GetEnvironmentVariable("MYSQLUSER");

        var connectionString = $"Server={MYSQLHOST};Port={MYSQLPORT};Database={MYSQLDATABASE};Uid={MYSQLUSER};Pwd={MYSQLPASSWORD};";

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<TodoModel> Todos { get; set; }
}