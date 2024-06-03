using OnlineLibrary.Domain.Entities;

namespace OnlineLibrary.Services.Interfaces
{
	public interface ICustomerService 
	{
  List<Customer> GetAll();

	 Customer GetById(int id);
		Customer Save(Customer costumer);
		void Remove(int id);
	}
}
