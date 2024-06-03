using OnlineLibrary.Data.Context;
using OnlineLibrary.Domain.Entities;
using System.Reflection;
using System.Security.Principal;

namespace OnlineLibrary.ConsoleTest
{
	internal class Program
	{
		static void Main(string[] args)
		{
		      	Book book = new Book()
			      {
				        Title = "Aprender.NET",
				        Description = "Livro para aprender.NET",
				        Author = "Jose Manuel",
				        Year = 2019,
			        	Category = "Tecnologia"
			      };
      
      OnlineLibraryDBContext onlineLibraryDBContext = new OnlineLibraryDBContext();
      
		}
	}
}