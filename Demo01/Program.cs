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

            // Configure the HTTP request pipeline(MiddleWares"Gates").
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
            // End of the HTTP request pipeline configuration.
            app.Run();
            // End of the Main method & Nothing after this line will be executed.
        }
    }
}
