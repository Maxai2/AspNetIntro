using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book GetBook(int id);
        Book AddBook(string title, int year);
    }
}
