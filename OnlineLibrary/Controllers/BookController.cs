using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Services.Interfaces;
using OnlineLibrary.Data.Entities;

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
    
    [HttpPost("create")]
    public Book Create(Book book) 
    {
      return _bookService.CreateBook(book);
    }
    
    [HttpPost("update")]
    public Book Update(Book book) 
    {
      return _bookService.UpdateBook(book);
    }
  
    [HttpDelete("{id}")]
    public void Remove(int id) 
    { 
      _bookService.Remove(id);
    }

	}
}
