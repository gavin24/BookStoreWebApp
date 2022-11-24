using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Integration.IServices
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
        Book GetBookByID(long bookId);
        void InsertBook(Book book);
        void DeleteBook(long bookId);
        void UpdateBook(Book book);
        void Save();
    }
}
