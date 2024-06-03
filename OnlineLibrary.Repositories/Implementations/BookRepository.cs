using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Data.Context;
using OnlineLibrary.Domain.Entities;
using OnlineLibrary.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly DbSet<Book> _dbSet;
        private readonly OnlineLibraryDBContext _onlineLibraryDBContext;

        public BookRepository(OnlineLibraryDBContext onlineLibraryDBContext)
        {
            _dbSet = onlineLibraryDBContext.Set<Book>();
			         _onlineLibraryDBContext = onlineLibraryDBContext;
        }

        public List<Book> GetAll()
        {
            return _dbSet.ToList(); // select * from books
        }
  
        public Book GetById(int id) 
        { 
          return _dbSet.FirstOrDefault(p => p.Id == id);
        }

        public Book Add(Book book)
        {
            _dbSet.Add(book);  // insert into books (title, ...) values ('test',....
		         	_onlineLibraryDBContext.SaveChanges();
		           return book;
        }

        public Book Update(Book book)
        {
            _dbSet.Update(book); // update books set title = 'test'..... where id = 1
		         	_onlineLibraryDBContext.SaveChanges();
		          	return book;
  
        }

        public void Remove(Book book)
        {
            _dbSet.Remove(book);  // delete from books where id 1
           
            _onlineLibraryDBContext.SaveChanges();
        }
    }
}
