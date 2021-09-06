using System;

namespace Codecool.BookDb.View
{
    public class UserInterface
    {
        public void PrintLn(Object obj)
        {
            Console.WriteLine(obj);
        }

        public void PrintTitle(string title)
        {
            Console.WriteLine("\n --" + title + " --");
        }

        public void PrintOption(char option, string description)
        {
            Console.WriteLine("(" + option + ")" + " " + description);
        }

        public char Choice(string options)
        {
            // Given string options -> "abcd"
            // keep asking user for input until one of provided chars is provided
            char option;
            Console.WriteLine(options);
            try
            {
                string userInput = Console.ReadLine();
                option = char.Parse(userInput);
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            return option;
        }

        public string ReadString(string prompt, string defaultValue)
        {
            // Ask user for data. If no data was provided use default value.
            // User must be informed what the default value is.
            Console.WriteLine(prompt);
            string userInput = Console.ReadLine();
            if (userInput != string.Empty)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine($"Input is empty, program will use default data, '{defaultValue}'");
                return defaultValue;
            }
        }

        public DateTime ReadDate(string prompt, DateTime defaultValue)
        {
            // Ask user for a date. If no data was provided use default value.
            // User must be informed what the default value is.
            // If provided date is in invalid format, ask user again.
            DateTime date;
            bool dateIsValid;
            do
            {
                dateIsValid = DateTime.TryParse(Console.ReadLine(), out date);
                if (dateIsValid)
                {
                    Console.WriteLine($"Date is not valid! Use this format {default}");
                    Console.WriteLine("Try again...");
                }
            } while (dateIsValid);
            return date;
        }
        
        public int ReadInt(string prompt, int defaultValue)
        {
            // Ask user for a number. If no data was provided use default value.
            // User must be informed what the default value is.
            Console.WriteLine(prompt);
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }
}
