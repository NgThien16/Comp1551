using System;
using System.Collections.Generic;

namespace Lecture7
{
    class Book
    {
        //attributes
        private string _name;
        private int _qty;
        private bool _isBorrowed;

        //properties
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new Exception("Name must be valid (at least 3 characters).");
                }
                _name = value;
            }
        }

        public int Qty
        {
            get { return _qty; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Qty must be positive");
                }
                _qty = value;
            }
        }

        public bool IsBorrowed
        {
            get { return _isBorrowed; }
            private set { _isBorrowed = value; }
        }

        //constructor
        public Book(string name, int qty)
        {
            Name = name;
            Qty = qty;
        }

        //override ToString
        public override string ToString()
        {
            return $"Book Name: {Name}, Quantity: {Qty}";
        }
    }
    internal class Program
    {
        private static void ShowMenu()
        {
            List<Book> bookList = new List<Book>();
         

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n----------Menu------------");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Display Book");
                Console.WriteLine("3. Edit Book");
                Console.WriteLine("4. Remove Book");
                Console.WriteLine("5. Exit");
                Console.Write("Please choose from 1–5: ");

                string userChoice = Console.ReadLine();
                Console.WriteLine($"User has chosen: {userChoice}");

                switch (userChoice)
                {
                    case "1": // Add book
                        Console.Write("Enter new book name: ");
                        string bookName = Console.ReadLine();
                        Console.Write("Enter quantity of this book: ");
                        int qtyBook = int.Parse(Console.ReadLine());
                        
                        Book book = new Book(bookName, qtyBook);
                        bookList.Add(book);
                        Console.WriteLine("Book added successfully!");
                        break;

                    case "2": // Display book
                        if (bookList.Count == 0)
                        {
                            Console.WriteLine(" No books available!");
                        }
                        else
                        {
                            Console.WriteLine("\n===Book List ===");
                            for (int i = 0; i < bookList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {bookList[i]}");
                            }
                        }
                        break;

                    case "3": // edit
                        Console.Write("Enter book name to edit: ");
                        string editName = Console.ReadLine();

                        break;

                    case "4": // remove
                        Console.WriteLine("Input name to delete");
                        string deleteName = Console.ReadLine();
                        bool found = true;

                        for (int i = 0; i < bookList.Count; i++)
                        {
                            if( bookList[i].Name.Equals(deleteName, StringComparison.OrdinalIgnoreCase))
                            {
                                bookList.RemoveAt(i);
                                found = true;
                            }
                        }
                        if (found)
                        {
                            Console.WriteLine("Remove Successfull");
                        }
                        else
                        {
                            Console.WriteLine("can not found name of book");
                        }
                        
                        break;

                    case "5":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine(" Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            ShowMenu();
        }
    }
}
