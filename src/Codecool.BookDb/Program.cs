using Codecool.BookDb.Model;
using Codecool.BookDb.Controller;
using System;
using System.Collections.Generic;

namespace Codecool.BookDb
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            new BooksController().ShowBooksMainMenu();
        }
    }
}
