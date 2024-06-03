using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Data.Context;
using OnlineLibrary.Domain.Entities;
using OnlineLibrary.Repositories.Implementations;
using OnlineLibrary.Services.Implementations;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Controllers
{
	[Route("OnlineLibraryApi/[Controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerService;


		public CustomerController(ICustomerService customerService)
		{
			 _customerService = customerService;

		}
		[HttpGet]
		public List<Customer> GetAll()
		{
			return _customerService.GetAll();
		}

		[HttpGet("{id}")]
		public Customer GetById(int id)
		{
			return _customerService.GetById(id);
		}

		[HttpPost]
		public Customer Save(Customer customer)
		{
			return _customerService.Save(customer);
		}

		[HttpDelete("{id}")]
		public void Remove(int id)
		{
			_customerService.Remove(id);
		}
	}
}

