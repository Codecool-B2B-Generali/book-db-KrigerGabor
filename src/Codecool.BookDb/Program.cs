using Codecool.BookDb.Model;
using System;
using System.Collections.Generic;

namespace Codecool.BookDb
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Author author = new Author();
            //List<Author> authors = author.GetAll();
            //Console.WriteLine(author.Get(1));
            //author.Add(new Author("John", "Doe", new DateTime(2000,01,01)));
            //author.Update(new Author(11, "John", "Doe", new DateTime(1990, 01, 01)));
            //foreach (var item in authors)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            Book book = new Book();
            List<Book> books = book.GetAll();
            foreach (var item in books)
            {
                Console.WriteLine(item);
            }
        }
    }
}
