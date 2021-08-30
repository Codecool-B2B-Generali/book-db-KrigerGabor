using Codecool.BookDb.Model;
using System;
using System.Collections.Generic;

namespace Codecool.BookDb
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Author author = new Author();
            List<Author> authors = author.GetAll();
            foreach (var authorItem in authors)
            {
                Console.WriteLine(authorItem.ToString());
            }

        }
    }
}
