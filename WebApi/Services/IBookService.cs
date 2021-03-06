﻿using System.Collections.Generic;
using WepApi.Models;

namespace WepApi.Services
{
    public interface IBookService
    {
        List<Book> Get();
        Book Get(int id);
        Book Insert(Book book);
        Book Update(Book book);
        void Delete(int id);
        void Delete(Book book);
        List<Author> GetAuthors(int id);
    }
}
