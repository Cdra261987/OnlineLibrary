using OnlineLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Repositories.Interfaces
{
	public interface ICustomerRepository
	{

		List<Customer> GetAll();
		Customer GetById(int id);
		Customer Add(Customer customer);
		Customer Update(Customer customer);
		void Remove(Customer customer);
	}
}
