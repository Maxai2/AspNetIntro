using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book GetBook(int id);
        Book AddBook(string title, int year);
    }
}
