using Codecool.BookDb.Manager;
using System.Collections.Generic;

namespace Codecool.BookDb.Model
{
    public class Book : IBookDao
    {
        public int Id { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }

        public Book()
        {

        }

        public Book(Author author, int id, string title)
        {
            Id = id;
            Author = author;
            Title = title;
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
            return new BookDbManager().GetAllBooksWithAuthor();
        }
        public override string ToString()
        {
            return new string($"{Id}, {Title}, {Author.Id}, {Author.FirstName}, {Author.LastName}");
        }
    }
}
