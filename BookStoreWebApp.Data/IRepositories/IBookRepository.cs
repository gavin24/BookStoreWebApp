using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.IRepositories
{
    public interface IBookRepository : IDisposable
    {
        IEnumerable<Book> GetBooks();
        Book GetBookByID(long bookId);
        void InsertBook(Book book);
        void DeleteBook(long bookId);
        void UpdateBook(Book book);
        void Save();
    }
}
