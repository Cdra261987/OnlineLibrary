using OnlineLibrary.Data.Entities;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
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


        public Book CreateBook(Book book)
        {
            _bookRepository.Add(book);
            var changes = _bookRepository.SaveChanges();

            if (changes == 0)
                throw new InvalidOperationException($"Failed to create book with title {book.Title}");

            return book;
        }
        
        public Book UpdateBook(Book book)
        {
            _bookRepository.Update(book);
            var changes = _bookRepository.SaveChanges();

            if (changes == 0)
                throw new InvalidOperationException($"Failed to create book with title {book.Title}");

            return book;
        }

        public void Remove(int id)
        {
            _bookRepository.Delete(id);
        }
    }
}