using Codecool.BookDb.Manager;
using System.Collections.Generic;

namespace Codecool.BookDb.Model
{
    public class Book : IBookDao
    {
        public int Id { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }


        public Book(Author author, string title)
        {
            Author = author;
            Title = title;
        }

        public override string ToString()
        {
            return new string($"{Id}, {Title}, {Author.FirstName}, {Author.LastName}");
        }

        public void Add(Book book)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Book book)
        {
            throw new System.NotImplementedException();
        }

        public Book Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Book> GetAll()
        { 
            throw new System.NotImplementedException();
        }
    }
}
