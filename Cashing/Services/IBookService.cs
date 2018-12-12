using System.Collections.Generic;
using Caching.Models;

namespace Caching.Services
{
    public interface IBookService
    {
        void Initialize();
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        Book AddBook(Book book);
    }
}
