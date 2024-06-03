using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Entities;

namespace OnlineLibrary.Data.Context
{
	public class OnlineLibraryDBContext : DbContext
	{
    public DbSet<Book> Books { get; set; }
		  public DbSet<Customer> Costumers { get; set; }
		  public DbSet<CustomerBook> CustomerBooks { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=localhost; database=OnlineLibraryDB_EF; integrated security=true;");
		}
		//protected override void OnModelCreating(ModelBuilder mb)
		//{
		//    mb.Entity<Book>().ToTable("Booksssss").HasKey(k => k.Id);
		//}
	}
}
