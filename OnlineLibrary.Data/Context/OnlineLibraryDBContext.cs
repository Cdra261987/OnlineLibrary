using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Data.Entities;

namespace OnlineLibrary.Data.Context
{
	public class OnlineLibraryDBContext : DbContext
	{
		public DbSet<Book> Books { get; set; } 
		public DbSet<Customer> Costumers { get; set; }
		public DbSet<CustomerBook> CustomerBooks { get; set; }

		public OnlineLibraryDBContext(DbContextOptions<OnlineLibraryDBContext> optionsBuilder)
			:base(optionsBuilder)
		{
		}
	}
}
