using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HtmlHelpers.Models;

namespace HtmlHelpers.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> books = new List<Book>()
        {
            new Book() { Id = 1, Title = "Book 1", Year = 1994 },
            new Book() { Id = 2, Title = "Book 2", Year = 1995 },
            new Book() { Id = 3, Title = "Book 3", Year = 1997 },
            new Book() { Id = 4, Title = "Book 4", Year = 1997 },
            new Book() { Id = 5, Title = "Book 5", Year = 1998 },
        };

        [HttpGet]
        public IActionResult All()
        {
            return View(books);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Book book = books.Find(b => b.Id == id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            Book oldBook = books.Find(b => b.Id == book.Id);
            oldBook.Title = book.Title;
            oldBook.Year = book.Year;
            return RedirectToAction("All");
        }
    }
}