using OnlineLibrary.Domain.Entities;

namespace OnlineLibrary.Repositories.Interfaces
{
	public interface IBookRepository
	{
		List<Book> GetAll();
		Book GetById(int id);
		Book Add(Book book);
		Book Update(Book book);
		void Remove(Book book);

		
  


	}
}
