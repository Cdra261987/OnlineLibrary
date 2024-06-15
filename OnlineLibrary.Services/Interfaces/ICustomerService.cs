using OnlineLibrary.Data.Entities;

namespace OnlineLibrary.Services.Interfaces
{
	public interface ICustomerService 
	{
		List<Customer> GetAll();
		Customer GetById(int id);
		Customer Create(Customer customer);
		Customer Update(Customer customer);

		void Remove(int id);
	}
}
