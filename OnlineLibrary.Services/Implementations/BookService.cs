using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Entities;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace OnlineLibrary.Services.Implementations
{
	public class BookService : IBookService
	{
		private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
             _bookRepository = bookRepository;
        }
 
        public List<Book> GetAll()
        {
          return _bookRepository.GetAll();
        }

		      public Book GetById(int id)
		      {
			        return _bookRepository.GetById(id);
		      }


		      public Book Save(Book book) 
        { 
            if (book.Id == 0) 
            { 
              return _bookRepository.Add(book);
            }
            else 
            {
              return _bookRepository.Update(book);
            }


        }
        
        public void Remove (int id) 
        { 
         Book book = _bookRepository.GetById(id);
         _bookRepository.Remove(book);
         
        }


	}
}
