using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Entities;
using OnlineLibrary.Repositories.Implementations;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Services.Implementations
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerService(ICustomerRepository customerRepository)
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
		public Customer Save(Customer customer)
		{
			if (customer.Id == 0)
			{
				return _customerRepository.Add(customer);
			}
			else
			{
				return _customerRepository.Update(customer);
			}
		}

		public void Remove(int id)
		{
			Customer customer = _customerRepository.GetById(id);
			_customerRepository.Remove(customer);

		}


	}
}

