using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Domain.Entities;
using OnlineLibrary.Services.Interfaces;
using System.Diagnostics.Eventing.Reader;

namespace OnlineLibrary.Controllers
{
  [Route("OnlineLibraryApi/[Controller]")]
  [ApiController]
	public class BookController : ControllerBase
	{
		  private readonly IBookService _bookService;
    

    public BookController(IBookService bookService)
    {
			    _bookService = bookService;
   
		  }
    [HttpGet]
    public		List<Book> GetAll()
    {
      return _bookService.GetAll();
    }
    
    [HttpGet("{id}")]
    public Book GetById (int id) 
    { 
      return _bookService.GetById(id);
    }
    
    [HttpPost]
    public Book Save(Book book) 
    {
      return _bookService.Save(book);
    }
  
  
    [HttpDelete("{id}")]
    public void Remove(int id) 
    { 
      _bookService.Remove(id);
    }

	}
}
