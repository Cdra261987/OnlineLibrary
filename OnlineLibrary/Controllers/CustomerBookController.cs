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
	public class CustomerBookController : ControllerBase
	{
		private readonly ICustomerBookService _customerbookService;
		

		public CustomerBookController(ICustomerBookService customerbookService)
		{
			_customerbookService = customerbookService;

		}
		
   [HttpGet]
		 public List<CustomerBook> GetAll()
		 {
			return _customerbookService.GetAll();
		 }

		 [HttpGet("{id}")]
		 public CustomerBook GetById(int id)
		 {
			return _customerbookService.GetById(id);
		 }

		 [HttpPost]
		 public CustomerBook Save(CustomerBook customerbook)
		 {
			return _customerbookService.Save(customerbook);
		 }

		 [HttpDelete("{id}")]
		 public void Remove(int id)
		 {
			_customerbookService.Remove(id);
		}
	}
}
