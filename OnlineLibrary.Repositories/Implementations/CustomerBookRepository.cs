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
    public class CustomerBookRepository :  ICustomerBookRepository
    {
        private readonly DbSet<CustomerBook> _dbSet;
		      private readonly OnlineLibraryDBContext _onlineLibraryDBContext;

		public CustomerBookRepository(OnlineLibraryDBContext onlineLibraryDBContext)
        {
            _dbSet = onlineLibraryDBContext.Set<CustomerBook>();
			         _onlineLibraryDBContext = onlineLibraryDBContext;
        }

        public List<CustomerBook> GetAll()
        {
            return _dbSet.ToList(); // select * from books
        }
            //return _dbSet.Include(p => p.Customer).Include(p => p.Book).ToList();

		      public CustomerBook GetById(int id)
		      {
			       return _dbSet.FirstOrDefault(p => p.Id == id);
		      }


		public CustomerBook Add(CustomerBook customerBook)
        {
            _dbSet.Add(customerBook);  // insert into books (title, ...) values ('test',....
			         _onlineLibraryDBContext.SaveChanges();
			         return customerBook;
        }

        public CustomerBook Update(CustomerBook customerBook)
        {
            _dbSet.Update(customerBook); // update books set title = 'test'..... where id = 1
			         _onlineLibraryDBContext.SaveChanges();
			         return customerBook;
        }

        public void Remove(CustomerBook customerBook)
        {
            _dbSet.Remove(customerBook);  // delete from books where id 1

        }
    }
}
