using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using todoapp_mvc_net.DB;
using todoapp_mvc_net.Models;
using todoapp_mvc_net.Services.Common;

namespace todoapp_mvc_net;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUi(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddDbContext<DataContext>();
        services.AddIdentity<UserModel, IdentityRole>()
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<TodoListService>();
        services.AddScoped<TodoService>();

        services.Configure<IdentityOptions>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedAccount = false;
        });
        return services;
    }
}