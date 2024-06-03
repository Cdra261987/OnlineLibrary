using Microsoft.OpenApi.Models;
using OnlineLibrary.Data.Context;
using OnlineLibrary.Repositories.Implementations;
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

			ConfigureServices(builder.Services);

			var app = builder.Build();

			ConfigureApp(app);
		}

  private static void ConfigureServices(IServiceCollection services) 
  { 
     services.AddControllers();

			services.AddDbContext<OnlineLibraryDBContext>();

			services.AddScoped<IBookRepository, BookRepository>();
			services.AddScoped<ICustomerRepository, CustomerRepository>();
			services.AddScoped<ICustomerBookRepository, CustomerBookRepository>();

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
			});

		}

  private static void ConfigureApp(WebApplication app)
  {

			app.UseHttpsRedirection();
   app.UseRouting();
   app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

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