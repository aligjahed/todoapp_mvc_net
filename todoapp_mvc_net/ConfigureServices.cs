using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using todoapp_mvc_net.DB;
using todoapp_mvc_net.Models;
using todoapp_mvc_net.Services.Common;
using todoapp_mvc_net.Services.MigrationService;

namespace todoapp_mvc_net;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUi(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddDbContext<DataContext>();
        services.AddRazorPages();
        services.AddIdentity<UserModel, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
            })
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<TodoService>();
        services.AddScoped<MigrationService>();

        // services.Configure<IdentityOptions>(options =>
        // {
        //     options.User.RequireUniqueEmail = true;
        //     options.SignIn.RequireConfirmedAccount = false;
        //     options.SignIn.RequireConfirmedEmail = false;
        // });
        return services;
    }
}