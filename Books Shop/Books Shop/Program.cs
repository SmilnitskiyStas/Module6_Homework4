using Books_Shop.Filters;
using Books_Shop.Infrastructura;
using Books_Shop.Interfaces;
using Books_Shop.Services;

namespace Books_Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddSingleton<IDataProvider, MemoryDataProvider>();

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<MyCustomExceptionFilterAttribute>();
            });

            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}