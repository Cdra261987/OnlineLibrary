using System.Net;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Data.Entities;
using OnlineLibrary.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

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
		[Produces("application/json")]
		[ProducesResponseType(typeof(List<Customer>), (int) HttpStatusCode.OK)]
		public List<Customer> GetAll()
		{
			return _customerService.GetAll();
		}

		[HttpGet("{id}")]
		[SwaggerOperation(Summary = "Gets customer by id")]
		[Produces("application/json")]
		[ProducesResponseType(typeof(List<Customer>), (int) HttpStatusCode.OK)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(void), 500)]
		public Customer GetById(int id)
		{
			return _customerService.GetById(id);
		}

		
		 [HttpPost("create")]
		 public Customer Create(Customer customer)
		 {
			return _customerService.Create(customer);
		 }
		 
		 
		 [HttpPost("update")]
		 public Customer Update(Customer customer)
		 {
			 return _customerService.Update(customer);
		 }

		[HttpDelete("{id}")]
		public void Remove(int id)
		{
			_customerService.Remove(id);
		}
	}
}

