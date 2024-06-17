using OnlineLibrary.Data.Entities;

namespace OnlineLibrary.Services.Interfaces
{
	public interface ICustomerBookService
	{
		List<CustomerBook> GetAll();

		CustomerBook GetById(int id);
		CustomerBook CreateCustomerBook(CustomerBook costumerbock);
		CustomerBook UpdateCustomerBook(CustomerBook costumerbock);
		void Remove(int id);
	}
}
