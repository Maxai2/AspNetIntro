using System;
using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class BooksDateViewModel
    {
        public List<Book> Books { get; set; }
        public DateTime CurrentTime { get; set; }
    }
}
