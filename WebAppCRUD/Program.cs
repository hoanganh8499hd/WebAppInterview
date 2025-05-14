using Microsoft.EntityFrameworkCore;
using WebAppCRUD.Models;

namespace WebAppCRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. builder.Services: 
            // builder.Services refers to the IServiceCollection provided by the ASP.NET Core host builder. 
            // This collection registers services that the application will use, including platform features 
            // like MVC, logging, DI containers, and more.

            // 2. AddDbContext<EFCoreDbContext>: 
            // AddDbContext is an extension method provided by EF Core that registers the DbContext as a service 
            // in the Dependency Injection (DI) container. Here, it's registering EFCoreDbContext. This ensures that 
            // the lifecycle of the DbContext is managed correctly, typically as a scoped service. 
            // A new instance of the DbContext is created for each request.

            // 3. Lambda Configuration (options => …): 
            // The lambda expression is used to configure options for the DbContext. These options control 
            // how the DbContext behaves and interacts with the underlying database.

            // 4. options.UseSqlServer: 
            // UseSqlServer specifies SQL Server as the database provider for EF Core. This tells EF Core to translate 
            // LINQ queries and other data operations into SQL that is compatible with SQL Server.

            // 5. builder.Configuration.GetConnectionString(“EFCoreDBConnection”): 
            // builder.Configuration provides access to the application’s configuration, typically including settings 
            // from files like appsettings.json, environment variables, and other configuration sources. 
            // GetConnectionString retrieves a connection string by its key (“EFCoreDBConnection” in this case) 
            // from the application's configuration. This connection string contains the necessary information 
            // for connecting to the SQL Server database (server address, database name, credentials, etc.).

            builder.Services.AddDbContext<EFCoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("EFCoreDBConnection"));
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.Run();
        }
    }
}
