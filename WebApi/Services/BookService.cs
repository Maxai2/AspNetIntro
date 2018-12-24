using System.Collections.Generic;
using WepApi.Models;

namespace WepApi.Services
{
    public class BookService : IBookService
    {
        private List<Book> books;

        public BookService()
        {
            books = new List<Book>()
            {
                new Book() { Id = 1, Title = "Book 1", Year = 1990,
                    Authors = new List<Author>() { new Author() { Id = 1, FirstName = "Author", LastName = "One" }, new Author() { Id = 2, FirstName = "Author", LastName = "Two" } } },
                new Book() { Id = 2, Title = "Book 2", Year = 1991,
                    Authors = new List<Author>() { new Author() { Id = 3, FirstName = "Author", LastName = "Three" } } },
                new Book() { Id = 3, Title = "Book 3", Year = 1992,
                    Authors = new List<Author>() { new Author() { Id = 4, FirstName = "Author", LastName = "Four" }, new Author() { Id = 5, FirstName = "Author", LastName = "Five" } } },
                new Book() { Id = 4, Title = "Book 4", Year = 1993 },
                new Book() { Id = 5, Title = "Book 5", Year = 1994 }
            };
        }

        public List<Book> Get()
        {
            return books;
        }

        public Book Get(int id)
        {
            return books.Find(b => b.Id == id);
        }

        public Book Insert(Book book)
        {
            book.Id = books[books.Count - 1].Id + 1;
            books.Add(book);
            return book;
        }

        public Book Update(Book book)
        {
            Book find = books.Find(b => b.Id == book.Id);
            find.Title = book.Title;
            find.Year = book.Year;
            return find;
        }

        public void Delete(int id)
        {
            Book find = books.Find(b => b.Id == id);
            books.Remove(find);
        }

        public void Delete(Book book)
        {
            books.Remove(book);
        }

        public List<Author> GetAuthors(int id)
        {
            Book find = books.Find(b => b.Id == id);
            return find?.Authors;
        }

    }
}
