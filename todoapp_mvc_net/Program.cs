using Microsoft.EntityFrameworkCore;
using todoapp_mvc_net;
using todoapp_mvc_net.DB;
using Microsoft.AspNetCore.Identity;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Adding Database Context
using (var config = builder.Configuration)
{
    if (builder.Environment.IsDevelopment())
    {
        Console.WriteLine("Development DB Setup");
        var connectionString = config.GetConnectionString("MYSQL");
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
    }
    else
    {
        var MYSQLDATABASE = Environment.GetEnvironmentVariable("MYSQLDATABASE");
        var MYSQLHOST = Environment.GetEnvironmentVariable("MYSQLHOST");
        var MYSQLPASSWORD = Environment.GetEnvironmentVariable("MYSQLPASSWORD");
        var MYSQLPORT = Environment.GetEnvironmentVariable("MYSQLPORT");
        var MYSQLUSER = Environment.GetEnvironmentVariable("MYSQLUSER");

        var connectionString =
            $"Server={MYSQLHOST};Port={MYSQLPORT};Database={MYSQLDATABASE};Uid={MYSQLUSER};Pwd={MYSQLPASSWORD};";

        try
        {
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }
        catch
        {
            throw new Exception($"Database Connection With {connectionString} Failed");
        }
    }
}

// Add services to the container.
builder.Services.AddWebUi();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

// Apply migrations at runtime
using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider.GetService<DataContext>().Database.MigrateAsync();
}

app.Run();