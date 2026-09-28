using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using BookLibraryEF.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    const int maxRetries = 10;
    const int retryDelaySeconds = 5;

    for (int attempt = 1; attempt <= maxRetries; attempt++)
    {
        try
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider
                .GetRequiredService<LibraryContext>();

            await context.Database.MigrateAsync();

            Console.WriteLine("Database migration completed successfully.");
            break;
        }
        catch (SqlException ex) when (attempt < maxRetries)
        {
            Console.WriteLine(
                $"Database connection failed. " +
                $"Retrying in {retryDelaySeconds} seconds... " +
                $"Attempt {attempt}/{maxRetries}"
            );

            Console.WriteLine($"Error: {ex.Message}");

            await Task.Delay(
                TimeSpan.FromSeconds(retryDelaySeconds)
            );
        }
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Library}/{action=Index}/{id?}");

app.Run();