using ColorFight.Data;
using Microsoft.EntityFrameworkCore;

namespace ColorFight.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.AddSignalR();

        var app = builder.Build();

        try
        {
            using var context = new ColorFightDataContext(builder.Configuration.GetConnectionString("ConStr"));
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to migrate client database - {ex}");
        }


        if (!app.Environment.IsDevelopment())
        {
            app.UseHsts();
            app.UseHttpsRedirection();
        }

        app.UseStaticFiles();
        app.UseRouting();

        app.MapHub<ColorFightHub>("/api/colorhub");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");

        app.MapFallbackToFile("index.html");

        app.Run();
    }
}