using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OnlineLibrary.Data;
using OnlineLibrary.Data.Context;
using OnlineLibrary.Data.Entities;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Services.Implementations;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true,
                    reloadOnChange: true)
                .AddEnvironmentVariables();
            
            var configuration = builder.Configuration;
            ConfigureServices(configuration, builder.Services);

            var app = builder.Build();

            ConfigureApp(app);
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<OnlineLibraryDBContext>(cnf =>
                cnf.UseSqlServer(configuration.GetConnectionString("Database"),
                    opts =>
                    {
                        opts.MigrationsAssembly(typeof(OnlineLibraryDBContext).Assembly.FullName); 
                    }));

            services.AddScoped<IRepository<Book>, Repository<Book>>();
            services.AddScoped<IRepository<CustomerBook>, Repository<CustomerBook>>();
            services.AddScoped<IRepository<Customer>, Repository<Customer>>();

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerBookService, CustomerBookService>();


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "OnlineLibraryApi",
                    new OpenApiInfo()
                    {
                        Title = "Online Library Api",
                        Version = "1.0"
                    });
                options.EnableAnnotations();
            });
        }

        private static void ConfigureApp(WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<OnlineLibraryDBContext>();
            db.Database.Migrate();
            
            // Add custom exception handling middleware
            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("OnlineLibraryApi/Swagger.json", "Online Library Api");
            });

            app.Run();
        }
    }
}