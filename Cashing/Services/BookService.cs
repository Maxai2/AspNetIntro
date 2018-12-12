using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using Caching.EF;
using Caching.Models;

namespace Caching.Services
{
    public class BookService : IBookService
    {
        private LibContext context;
        private IMemoryCache cache;

        public BookService(LibContext context, IMemoryCache cache)
        {
            this.context = context;
            this.cache = cache;
        }

        public void Initialize()
        {
            if (context.Books.Count() == 0)
            {
                context.Books.AddRange(
                    new List<Book>()
                    {
                    new Book() { Title = "Book 1", Year = 1996 },
                    new Book() { Title = "Book 2", Year = 1993 },
                    new Book() { Title = "Book 3", Year = 1999 },
                    new Book() { Title = "Book 4", Year = 1991 },
                    new Book() { Title = "Book 5", Year = 1990 },
                    });
                context.SaveChanges();
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Books;
        }

        public Book GetBook(int id)
        {
            Book book = null;
            if (!cache.TryGetValue(id, out book))
            {
                book = context.Books.Find(id);
                cache.Set(id, book, TimeSpan.FromMinutes(1));
            }

            return book;
        }

        public Book AddBook(Book book)
        {
            context.Books.Add(book);
            int added = context.SaveChanges();

            if (added > 0)
            {
                cache.Set(book.Id, book, TimeSpan.FromMinutes(1));
            }

            return book;
        }

    }
}
