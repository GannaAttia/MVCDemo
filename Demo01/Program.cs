using Demo01.CustomMiddleware;
using Microsoft.Extensions.DependencyInjection;

namespace Demo01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region Services 
            // Add services to the container for API controllers.
            //builder.Services.AddControllers();

            // Add  Additional services to the container .
            //builder.Services.AddMvc();

            // Add services to the container for Razor Pages.
            //builder.Services.AddRazorPages();
            #endregion

            var app = builder.Build();

            #region Custom Middleware
            //app.Use(async (context , next) => {
            //    Console.WriteLine("Hello"); // Request 
            //    await next.Invoke();
            //    Console.WriteLine("Bye"); // Response
            //} );

            #endregion
            //app.UseMiddleware<RequestTimeMiddleware>();



            // Configure the HTTP request pipeline(MiddleWares"Gates").
            if (!app.Environment.IsDevelopment())
            {
                // Handle exceptions and display a custom error page in production.
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // Enable HTTPS redirection to ensure secure communication
            app.UseHttpsRedirection();
            // define which Conroller will handle the request , which action 
            app.UseRouting();
            // Identity (Cookie - JWT )
            app.UseAuthentication();
            // Authorization (Roles - Policies - Claims)
            app.UseAuthorization();

            // Serve static files (CSS, JS, images, etc.) from the wwwroot folder .NET 9
            app.MapStaticAssets();

            app.MapControllerRoute(
                    name: "shop",
                    pattern:"shop/{id}",
                    defaults: new { 
                        controller = "Product",
                        action = "GetProductById"
                    }
                ).WithStaticAssets();
            
            // Convention Routing: 
            // BaseUrl => Home Controller , Index Action
            // BasUrl/Product => Product Controller , Index Action
            // BaseUrl/Product/GetProducts => Product Controller , GetProducts Action
            // BaseUrl/Product/GetProductById/1 => Product Controller , GetProductById Action , id = 1

            // Patterns for routing incoming requests to the appropriate controllers and actions.
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}")
            //    .WithStaticAssets();
               

            app.Run();
            // End of the Main method & Nothing after this line will be executed.
        }
    }
}
