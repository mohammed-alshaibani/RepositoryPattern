using g13lec6.Models;
using g13lec6.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<group13Context>();
builder.Services.AddScoped<IRepository<Dept>, GenericRepository<Dept>>();
builder.Services.AddScoped<IRepository<Employee>, GenericRepository<Employee>>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
