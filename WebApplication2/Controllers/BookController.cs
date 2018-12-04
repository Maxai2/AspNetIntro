using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        private IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet] 
        public IActionResult All()
        {
            List<Book> books = bookService.GetBooks();
            DateTime curTime = DateTime.Now;
            BooksDateViewModel model = new BooksDateViewModel()
            {
                Books = books,
                CurrentTime = curTime
            };
            return View(model); // ViewResult
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            Book book = bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            
            return View(book); 
        }

        [HttpPost]
        //public IActionResult Add(string title, int year)
        public IActionResult Add(Book book)
        {
            //bookService.AddBook(title, year);
            bookService.AddBook(book.Title, book.Year);
            return new RedirectToActionResult("All", "Book", null);
        }

        [HttpPost]
        public IActionResult AddRandom()
        {
            Book book = bookService.AddBook("Book Ahmed", 1991);
            return PartialView("_BookItemPartial", book);
        }


    }
}