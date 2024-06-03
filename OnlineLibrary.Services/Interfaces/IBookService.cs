using OnlineLibrary.Domain.Entities;

namespace OnlineLibrary.Services.Interfaces
{
	public interface IBookService
	{
  List<Book> GetAll();
		Book GetById(int id);
		Book Save(Book book);
		void Remove(int id);
	}
}
