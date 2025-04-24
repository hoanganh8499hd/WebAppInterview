using Microsoft.AspNetCore.Http;
using System.Reflection.PortableExecutable;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileSystemGlobbing;
using System;
using Microsoft.AspNetCore.Routing;
using System.Net;
using System.Runtime.InteropServices;
using WebAppRouting.Models;

namespace WebAppRouting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Đăng ký Custom Constraint với hệ thống Routing
            builder.Services.AddRouting(options =>
            {
                options.ConstraintMap.Add("alphanumeric", typeof(AlphaNumericConstraint));
            });

            //builder.Services.Configure<RouteOptions>(options =>
            //{
            //    options.ConstraintMap.Add("alphanumeric", typeof(AlphaNumericConstraint));
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

            //UseRouting middleware parses the URL and matches it against the defined route templates stored in the route table
            //If no match is found, it will return a 404 error to the client.
            app.UseRouting();

            app.UseAuthorization();

            //Convention - Based Routing

            //Registration of Route Templates(MapControllerRoute):

            app.MapControllerRoute(
                name: "CustomRoute",
                pattern: "{controller}/{action}/{id:int?}",
                defaults: new { controller = "Home", action = "Index" }
            );


            //Custom Route Constraint có thể dùng cả với Convention-Based và Attribute-Based Routing
            app.MapControllerRoute(
                name: "CustomRoute",
                pattern: "{controller}/{action}/{id:alphanumeric?}",
                defaults: new { controller = "Home", action = "Index" }
            );

            //Default
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // tương đương với cái Tokens (Attribute Routing) : [Route("[controller]/[action]")]


            //MapControllerRoute không phải là middleware (Cấu hình endpoint) → không xử lý từng request
            //→ thứ tự trong file là sau, nhưng không ảnh hưởng đến pipeline runtime (chạy 1 lần khi app khởi động để đăng ký endpoint).

            //MapControllerRoute implicitly sets up the endpoint middleware (i.e., UseEndpoints) necessary for handling the routes.

            //The UseEndpoints middleware is responsible for executing the corresponding endpoints when a matching request comes in

            app.Run();
        }
    }
}
