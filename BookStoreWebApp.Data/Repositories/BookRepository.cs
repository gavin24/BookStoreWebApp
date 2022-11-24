using Microsoft.EntityFrameworkCore;
using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.Repositories
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private bool disposedValue;
        private BookStoreDbContext context;

        public BookRepository(BookStoreDbContext context)
        {
            this.context = context;
        }
        public void DeleteBook(long bookId)
        {
            Book books = context.Books.Find(bookId);
            context.Books.Remove(books);
            context.SaveChanges();
        }

        public Book GetBookByID(long bookId)
        {
            return context.Books.Find(bookId);
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Books.ToList();
        }

        public void InsertBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~BookRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
