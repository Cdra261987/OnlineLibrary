using OnlineLibrary.Data.Entities;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Services.Implementations
{
    public class CustomerBookService : ICustomerBookService
    {
        private readonly IRepository<CustomerBook> _customerbookRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Customer> _customerRepository;

        public CustomerBookService(IRepository<CustomerBook> customerbookRepository, 
            IRepository<Book> bookRepository,
            IRepository<Customer> customerRepository)
        {
            _customerbookRepository = customerbookRepository ?? throw new ArgumentNullException(nameof(customerbookRepository));
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public List<CustomerBook> GetAll()
        {
            List<CustomerBook> customerBooks = _customerbookRepository.GetAll();

            foreach (CustomerBook customerBook in customerBooks)
            {
                customerBook.Customer = _customerRepository.GetById(customerBook.CustomerId);
                customerBook.Book = _bookRepository.GetById(customerBook.BookId);
            }

            return customerBooks;
        }

        public CustomerBook GetById(int id)
        {
            return _customerbookRepository.GetById(id);
        }


        public CustomerBook CreateCustomerBook(CustomerBook customerbook)
        {
            _customerbookRepository.Add(customerbook);
            var changes = _customerbookRepository.SaveChanges();

            if (changes == 0)
                throw new InvalidOperationException("Failed to create customerbook entity");

            return customerbook;
        }
        
        public CustomerBook UpdateCustomerBook(CustomerBook customerbook)
        {
            _customerbookRepository.Add(customerbook);
            var changes = _customerbookRepository.SaveChanges();

            if (changes == 0)
                throw new InvalidOperationException("Failed to update customerbook entity");

            return customerbook;
        }

        public void Remove(int id)
        {
             _customerbookRepository.Delete(id);
        }
    }
}