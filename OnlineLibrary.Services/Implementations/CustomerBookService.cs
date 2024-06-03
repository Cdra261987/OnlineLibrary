using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Entities;
using OnlineLibrary.Repositories.Implementations;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Services.Implementations
{
	public class CustomerBookService : ICustomerBookService
	{
		private readonly ICustomerBookRepository _customerbookRepository;
		private readonly IBookRepository _bookRepository;
  private readonly ICustomerRepository _customerRepository;

		public CustomerBookService(ICustomerBookRepository customerbookRepository, IBookRepository bookRepository, ICustomerRepository customerRepository)
		{
			_customerbookRepository = customerbookRepository;
			_bookRepository = bookRepository;
			_customerRepository = customerRepository;
		}

		public List<CustomerBook> GetAll()
		{
    List<CustomerBook> customerBooks = _customerbookRepository.GetAll();
  
   foreach (CustomerBook customerBook in customerBooks) 
   { 
    customerBook.Customer = _customerRepository.GetById(customerBook.CustomerId);
    customerBook.book = _bookRepository.GetById(customerBook.BookId);
   
   }
			return customerBooks;
		}

		public CustomerBook GetById(int id)
		{
			return _customerbookRepository.GetById(id);
		}


		public CustomerBook Save(CustomerBook customerbook)
		{
			if (customerbook.Id == 0)
			{
				return _customerbookRepository.Add(customerbook);
			}
			else
			{
				return _customerbookRepository.Update(customerbook);
			}
		}

		public void Remove(int id)
		{
			CustomerBook customerbook = _customerbookRepository.GetById(id);
			_customerbookRepository.Remove(customerbook);

		}


	}
}

