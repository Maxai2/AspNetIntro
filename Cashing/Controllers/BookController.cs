using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Caching.Models;
using Caching.Services;

namespace Caching.Controllers
{
    public class BookController : Controller
    {
        private IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
            bookService.Initialize();
        }

        [HttpGet]
        public IActionResult All()
        {
            return View(bookService.GetBooks().ToList());
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return View(bookService.GetBook(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Book());
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            bookService.AddBook(book);
            return RedirectToAction("All");
        }
    }
}