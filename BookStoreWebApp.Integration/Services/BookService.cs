using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;
using BookStoreWebApp.Integration.IServices;

namespace BookStoreWebApp.Integration.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _iBookRepository;
        public BookService(IBookRepository iBookRepository)
        {
            _iBookRepository = iBookRepository;
        }

        public void DeleteBook(long bookId)
        {
            _iBookRepository.DeleteBook(bookId);
            
        }

        public Book GetBookByID(long bookId)
        {
            return _iBookRepository.GetBookByID(bookId);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _iBookRepository.GetBooks();
        }

        public void InsertBook(Book book)
        {
            _iBookRepository.InsertBook(book);
        }

        public void Save()
        {
            _iBookRepository.Save();
        }

        public void UpdateBook(Book book)
        {
            _iBookRepository.UpdateBook(book);
        }
    }
}
