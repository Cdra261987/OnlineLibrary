using OnlineLibrary.Domain.Entities;

namespace OnlineLibrary.Repositories.Interfaces
{
	public interface ICustomerBookRepository
	{

		List<CustomerBook> GetAll();
		CustomerBook GetById(int id);
		CustomerBook Add(CustomerBook customerBook);
		CustomerBook Update(CustomerBook customerBook);
		void Remove(CustomerBook customerBook);

	}
}
