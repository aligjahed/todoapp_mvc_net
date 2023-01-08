using Microsoft.EntityFrameworkCore;
using todoapp_mvc_net;
using todoapp_mvc_net.DB;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddWebUi();


var app = builder.Build();

// builder.Services.AddDbContext<DataContext>(opt =>
// {
//     opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
// });


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

app.Run();