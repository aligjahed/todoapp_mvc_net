using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using todoapp_mvc_net.DB;
using todoapp_mvc_net.Services.Common;

namespace todoapp_mvc_net;

public static class ConfigureServices  
{
    public static IServiceCollection AddWebUi(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddDbContext<DataContext>();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<TodoListService>();
        services.AddScoped<TodoService>();
        
        return services;
    }
}