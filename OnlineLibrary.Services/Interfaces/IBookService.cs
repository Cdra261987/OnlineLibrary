using OnlineLibrary.Data.Entities;

namespace OnlineLibrary.Services.Interfaces
{
	public interface IBookService
	{
		List<Book> GetAll();
		Book GetById(int id);
		Book CreateBook(Book book);
		Book UpdateBook(Book book);
		void Remove(int id);
	}
}
