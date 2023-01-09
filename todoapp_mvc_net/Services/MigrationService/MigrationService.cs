using Microsoft.EntityFrameworkCore;
using todoapp_mvc_net.DB;
using System.IO;


namespace todoapp_mvc_net.Services.MigrationService;

public class MigrationService
{
    private readonly DataContext _context;

    public MigrationService(DataContext context)
    {
        _context = context;
    }

    public async Task ApplyMigrationsFromScript()
    {
        string sqlQueries = File.ReadAllText("../../DB/all_migrations.sql");
        await _context.Database.ExecuteSqlRawAsync(sqlQueries);
    }
}