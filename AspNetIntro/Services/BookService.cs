using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetIntro.Models;

namespace AspNetIntro.Services
{
    public class BookService : IBookService
    {
        private List<Book> books = new List<Book>
        {
            new Book {Id = 1, Title = "Book 1", Year = 2001},
            new Book {Id = 2, Title = "Book 2", Year = 2002},
            new Book {Id = 3, Title = "Book 3", Year = 2003},
            new Book {Id = 4, Title = "Book 4", Year = 2004}
        };

        public Book AddBook(string title, int year)
        {
            var book = new Book
            {
                Id = books.Count + 1,
                Year = year,
                Title = title
            };

            books.Add(book);
            return book;
        }

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }
    }
}
