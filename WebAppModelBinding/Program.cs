namespace WebAppModelBinding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Environment.EnvironmentName = "Development";

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Logging.AddConsole();

            builder.Services.AddControllersWithViews(options =>
            {
                foreach (var provider in options.ModelBinderProviders)
                {
                    Console.WriteLine("------------" + provider.GetType().ToString());
                }
            });


            //builder.Services.AddLogging();
            //builder.Services.AddControllersWithViews(options =>
            //{
            //    var logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger("ModelBinderProviders");
            //    foreach (var provider in options.ModelBinderProviders)
            //    {
            //        logger.LogInformation(provider.GetType().ToString());
            //    }
            //});

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
