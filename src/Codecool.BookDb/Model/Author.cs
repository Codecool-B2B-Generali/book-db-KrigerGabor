using Codecool.BookDb.Manager;
using System;
using System.Collections.Generic;

namespace Codecool.BookDb.Model
{
    public class Author : IAuthorDao
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Author()
        {
        }

        public Author(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }


        public override string ToString()
        {
            return new string($"{Id}, {FirstName}, {LastName}, {BirthDate: MM/dd/yyyy}");
        }

        public void Add(Author author)
        {
            throw new NotImplementedException();
        }

        public void Update(Author author)
        {
            throw new NotImplementedException();
        }

        public Author Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAll()
        {
            BookDbManager bookDbManager = new BookDbManager();
            return bookDbManager.GetAllAuthors();
        }
    }
}
