using Codecool.BookDb.Model;
using Codecool.BookDb.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.BookDb.Controller
{
    public class BooksController
    {
        private readonly UserInterface ui;

        public BooksController()
        {
            ui = new UserInterface();
        }

        public void ShowBooksMainMenu()
        {
            char userChoise;
            do
            {
                PrintMainMenuOptions();

                try
                {
                    userChoise = ui.Choice("Type character: ");
                    ShowOptions(userChoise);
                }

                catch (FormatException)
                {
                    Console.WriteLine("Input type not valid");
                    Console.WriteLine("Try again, pls!");
                    Console.ReadKey();
                    Console.Clear();
                    userChoise = ' ';
                }

            } while ( !(userChoise == 'x' || userChoise == 'X'));
        }

        private void ShowOptions(char userChoise)
        {
            if (userChoise == 'a' || userChoise == 'A')
            {
                var authors = new Author().GetAll();
                foreach (var author in authors)
                {
                    Console.WriteLine(author.ToString());
                }
                Console.ReadKey();
                Console.Clear();
            }
            else if (userChoise == 'b' || userChoise == 'B')
            {
                var idx = ui.ReadInt("Type index number: ", 0);
                try
                {
                    Console.WriteLine(new Author().Get(idx));
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Key not exists! Try another key.");
                }
            }
            else if (userChoise == 'c' || userChoise == 'C')
            {
                var firstName = ui.ReadString("Type author first name: ", "exp: 'George'");
                var lastName = ui.ReadString("Type author last name: ", "exp: 'R. R. Martin'");
                var date = ui.ReadDate("Type author birth date :", new DateTime(1990,01,01));
                var author = new Author(firstName, lastName, date);
                author.Add(author);
                Console.WriteLine("New author add to database...");
                Console.ReadKey();
                Console.Clear();
            }
            else if (userChoise == 'd' || userChoise == 'D')
            {
                var idx = ui.ReadInt("Type index number: ", 0);
                try
                {
                    var firstName = ui.ReadString("Type author first name: ", "exp: 'George'");
                    var lastName = ui.ReadString("Type author last name: ", "exp: 'R. R. Martin'");
                    var date = ui.ReadDate("Type author birth date :", new DateTime(1990, 01, 01));
                    var author = new Author(idx, firstName, lastName, date);
                    author.Update(author);
                    Console.WriteLine("author update to database...");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Key not exists! Try another key.");
                }
            }
            else if (userChoise == 'e' || userChoise == 'E')
            {
                var books = new Book().GetAll();
                foreach (var book in books)
                {
                    Console.WriteLine(book.ToString());
                }
                Console.ReadKey();
                Console.Clear();
            }
            else if (userChoise == 'f' || userChoise == 'F')
            {
                var idx = ui.ReadInt("Type index number: ", 0);
                try
                {
                    Console.WriteLine(new Book().Get(idx));
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Key not exists! Try another key.");
                }
            }
            else if (userChoise == 'g' || userChoise == 'G')
            {
                var newAuthor = ui.Choice("New author? Y/N: ");
                do
                {
                    if (newAuthor == 'y' || newAuthor == 'Y') // New author
                    {
                        var firstName = ui.ReadString("Type author first name: ", "exp: 'George'");
                        var lastName = ui.ReadString("Type author last name: ", "exp: 'R. R. Martin'");
                        var date = ui.ReadDate("Type author birth date :", new DateTime(1990, 01, 01));
                        
                        var title = ui.ReadString("Type book title : ", "exp: 'Dune'");

                        Book newBook = new Book
                        {
                            Author = new Author
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                BirthDate = date
                            },
                            Title = title
                        };
                        newBook.Add(newBook);
                    }

                    if (newAuthor == 'n' || newAuthor == 'N') // Exists author
                    {
                        var idx = ui.ReadInt("Type index number: ", 0);
                        try
                        {
                            Author author = new Author().Get(idx);

                            var title = ui.ReadString("Type book title : ", "exp: 'Dune'");

                            Book newBook = new Book(author, title);
                            newBook.Add(newBook);
                        }
                        catch (KeyNotFoundException)
                        {
                            Console.WriteLine("Key not exists! Try another key.");
                        }
                    }

                } while (!(newAuthor == 'y' || newAuthor == 'Y' || newAuthor == 'n' || newAuthor == 'N'));
            }
            else if (userChoise == 'h' || userChoise == 'H')
            {
                var idx = ui.ReadInt("Type index number: ", 0);
                try
                {
                    var title = ui.ReadString("Type book title: ", "exp: 'Dune'");
                    Book book = new Book(idx, title);
                    book.Update(book);

                    Console.WriteLine("Book update to database...");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Key not exists! Try another key.");
                }
            }
        }

        private void PrintMainMenuOptions()
        {
            ui.PrintOption('A', "Show all authors");
            ui.PrintOption('B', "Show author by id");
            ui.PrintOption('C', "Create a new author");
            ui.PrintOption('D', "Update author by id");
            ui.PrintOption('E', "Show all authors and books");
            ui.PrintOption('F', "Show author and book by book id");
            ui.PrintOption('G', "Create a new book (and author)");
            ui.PrintOption('H', "Update book by id");
            ui.PrintOption('X', "exit");
        }
    }
}
