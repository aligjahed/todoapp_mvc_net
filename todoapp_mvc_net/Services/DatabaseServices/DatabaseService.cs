using Microsoft.EntityFrameworkCore;
using todoapp_mvc_net.DB;
using System.IO;


namespace todoapp_mvc_net.Services.MigrationService;

public class DatabaseService
{
    private readonly DataContext _context;

    public DatabaseService(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> IsDatabaseConnected()
    {
        return await _context.Database.CanConnectAsync();
    }

    public async Task ApplyMigrationsFromScript()
    {
        string sqlQueries = File.ReadAllText("../../DB/all_migrations.sql");
        await _context.Database.ExecuteSqlRawAsync(sqlQueries);
    }
}