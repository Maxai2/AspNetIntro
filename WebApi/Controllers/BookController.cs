using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Models;
using WepApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get() // getBooks
        {
            return new JsonResult(bookService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) // getBook
        {
            return new JsonResult(bookService.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Book book) // addBook
        {
            book = bookService.Insert(book);
            return new JsonResult(book) { StatusCode = 201 };
        }

        [HttpPut]
        public IActionResult Put([FromBody]Book book) // changeBook
        {
            book = bookService.Update(book);
            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bookService.Delete(id);
            return StatusCode(204);
        }

        // api/book/1/authors

        [HttpGet("{id}/authors")]
        public IActionResult AuthorsGetById(int id)
        {
            return new JsonResult(bookService.GetAuthors(id));
        }
    }
}
