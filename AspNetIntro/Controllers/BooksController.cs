using AspNetIntro.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetIntro.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = this.bookService.GetBooks();
            return View(books);
        }

        [HttpPost]
        public IActionResult Create(string title, int year)
        {
            this.bookService.AddBook(title, year);

            return RedirectToAction("Index");

            //return new RedirectToActionResult("Index", "Book", null);
        }
    }
}
