using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class BooksDateViewModel
    {
        public List<Book> Books { get; set; }
        public DateTime CurrentTime { get; set; }
    }
}
