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
        }

        private void PrintMainMenuOptions()
        {
            ui.PrintOption('A', "Show all authors");
            ui.PrintOption('B', "Show author by id");
            ui.PrintOption('C', "Create a new author");
            ui.PrintOption('D', "Update author by id");
            ui.PrintOption('E', "Show all authors and books");
            ui.PrintOption('F', "Show author and book by book id");
            ui.PrintOption('F', "Create a new book (and author)");
            ui.PrintOption('F', "Update book by id");
            ui.PrintOption('X', "exit");
        }
    }
}
