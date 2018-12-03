using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BookService : IBookService
    {
        private List<Book> books = new List<Book>()
        {
            new Book() { Id = 1, Title = "Book 1", Year = 2000 },
            new Book() { Id = 2, Title = "Book 2", Year = 2001 },
            new Book() { Id = 3, Title = "Book 3", Year = 2002 },
            new Book() { Id = 4, Title = "Book 4", Year = 2003 },
            new Book() { Id = 5, Title = "Book 5", Year = 2004 }
        };

        public List<Book> GetBooks()
        {
            return books;
        }

        public Book AddBook(string title, int year)
        {
            Book book = new Book()
            {
                Id = books.Count + 1,
                Title = title,
                Year = year
            };
            books.Add(book);
            return book; 
        }

        public Book GetBook(int id)
        {
            return books.Find(b => b.Id == id);
        }
    }
}
