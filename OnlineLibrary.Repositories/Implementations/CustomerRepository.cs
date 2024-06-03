using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Data.Context;
using OnlineLibrary.Domain.Entities;
using OnlineLibrary.Repositories.Interfaces;

namespace OnlineLibrary.Repositories.Implementations
{
	public class CustomerRepository : ICustomerRepository
    {
        private readonly DbSet<Customer> _dbSet;
		      private readonly OnlineLibraryDBContext _onlineLibraryDBContext;

		public CustomerRepository(OnlineLibraryDBContext onlineLibraryDBContext)
        {
            _dbSet = onlineLibraryDBContext.Set<Customer>();
        }

        public List<Customer> GetAll()
        {
            return _dbSet.ToList(); // select * from books
        }

	      	public Customer GetById(int id)
		      {
		         	return _dbSet.FirstOrDefault(p => p.Id == id);
		      }


		      public Customer Add(Customer customer)
        {
            _dbSet.Add(customer);  // insert into books (title, ...) values ('test',....
			         _onlineLibraryDBContext.SaveChanges();
			         return customer;
        }

        public Customer Update(Customer customer)
        {
            _dbSet.Update(customer); // update books set title = 'test'..... where id = 1
			         _onlineLibraryDBContext.SaveChanges();
			         return customer;
        }

        public void Remove(Customer customer)
        {
            _dbSet.Remove(customer);  // delete from books where id 1

        }
    }
}
