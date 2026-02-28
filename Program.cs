using Microsoft.EntityFrameworkCore;
using IS413_ToDoList.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TaskDbContext>(Options => Options.UseSqlite(builder.Configuration.GetConnectionString("TaskConnection")));
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{

    var context = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
    context.Database.Migrate();

    var repo = scope.ServiceProvider.GetRequiredService<ITaskRepository>();
    var categories = repo.GetAllCategories();
    foreach (var cat in categories)
    {
        Console.WriteLine($"Category: {cat.CategoryName}");
    }
}

app.Run();


