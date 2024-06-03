using OnlineLibrary.Domain.Entities;

namespace OnlineLibrary.Services.Interfaces
{
	public interface ICustomerBookService
	{
  List<CustomerBook> GetAll();

		CustomerBook GetById(int id);
		CustomerBook Save(CustomerBook costumerbock);
		void Remove(int id);
	}
}
