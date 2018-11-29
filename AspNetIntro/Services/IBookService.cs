using AspNetIntro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetIntro.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
        Book AddBook(string title, int year);
    }
}
