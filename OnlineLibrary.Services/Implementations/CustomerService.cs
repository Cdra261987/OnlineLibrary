using OnlineLibrary.Data.Entities;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Services.Implementations
{
	public class CustomerService : ICustomerService
	{
		private readonly IRepository<Customer> _customerRepository;

		public CustomerService(IRepository<Customer> customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public List<Customer> GetAll()
		{
			return _customerRepository.GetAll();
		}

		public Customer GetById(int id)
		{
			return _customerRepository.GetById(id);
		}

		public Customer Create(Customer customer)
		{
			_customerRepository.Add(customer);
			var changes = _customerRepository.SaveChanges();

			if (changes == 0)
				throw new InvalidOperationException($"Failed to create customer with name {customer.Name}");

			return customer;
		}

		public Customer Update(Customer customer)
		{
			_customerRepository.Update(customer);
			var changes = _customerRepository.SaveChanges();

			if (changes == 0)
				throw new InvalidOperationException($"Failed to create customer with name {customer.Name}");

			return customer;
		}
		

		public void Remove(int id)
		{
			_customerRepository.Delete(id);
		}


	}
}

