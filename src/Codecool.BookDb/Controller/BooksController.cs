using Codecool.BookDb.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.BookDb.Controller
{
    public class BooksController
    {
        private UserInterface ui;

        public BooksController()
        {
            ui = new UserInterface();
        }

        public void ShowBooksMainMenu()
        {
            char userChoise;
            do
            {
                ui.PrintOption('A', "Show all authors");
                ui.PrintOption('X', "exit");

                try
                {
                    userChoise = ui.Choice("Type character: ");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input type not valid");
                    Console.WriteLine("Try again, pls!");
                    Console.ReadKey();
                    Console.Clear();
                    userChoise = ' ';
                }
                

            } while (userChoise != 'X');
        }

    }
}
