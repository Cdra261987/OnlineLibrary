using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Data.Entities;
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

		 [HttpPost("create")]
		 public CustomerBook Create(CustomerBook customerbook)
		 {
			return _customerbookService.CreateCustomerBook(customerbook);
		 }
		 
		 [HttpPost("update")]
		 public CustomerBook Update(CustomerBook customerbook)
		 {
			 return _customerbookService.UpdateCustomerBook(customerbook);
		 }
		 
		 [HttpDelete("{id}")]
		 public void Remove(int id)
		 {
			_customerbookService.Remove(id);
		}
	}
}
