using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// IGME-106 - Game Development and Algorithmic Problem Solving
/// Homework 2
/// Class Description   : Main program
/// Author              : Benjamin Kleynhans
/// Modified By         : Benjamin Kleynhans
/// Date                : March 31, 2018
/// Filename            : Program.cs
/// </summary>
namespace Homework3
{
    class Program
    {
        private static List<string> commandList = new List<string>();                       // Create list to hold command list
        private static CustomLinkedList myList = new CustomLinkedList();                    // Create custom linked list

        private static Random myRandom = new Random();                                      // Random number generator

        public static Random MyRandom
        {
            get { return myRandom; }
        }

        public static List<string> CommandList
        {
            get { return commandList; }
            set { commandList = value; }
        }

        public static CustomLinkedList Mylist
        {
            get { return myList; }
            set { myList = value; }
        }

        static void Main(string[] args)
        {
            PopulateCommandList();
                        
            string userInput = null;

            Console.WriteLine("Welcome to the Liked List homework!");
            Console.WriteLine();

            do                                                                              // Loop the program until the user chooses q or quit
            {
                userInput = GetUserInput(userInput);                                        // Acquire user input
                ProcessUserInput(userInput);                                                // Process user input

                if ((userInput == "q" || userInput == "quit"))
                {
                    Console.WriteLine("Thanks for typing!");
                }

            } while ((userInput != "q") && (userInput != "quit"));
        }

        /// <summary>
        /// Populate the command list
        /// </summary>
        private static void PopulateCommandList()
        {
            CommandList.Add("q");                                                           // Set up the list of commands to test for
            CommandList.Add("quit");
            CommandList.Add("print");
            CommandList.Add("count");
            CommandList.Add("clear");
            CommandList.Add("remove");
            CommandList.Add("backwards");
            CommandList.Add("scramble");
        }

        /// <summary>
        /// Get input from the user
        /// </summary>
        /// <param name="userInput">The user input</param>
        /// <returns></returns>
        protected static string GetUserInput(string userInput)
        {   
            Console.Write("Type something: ");
            userInput = Console.ReadLine();

            return userInput;
        }

        /// <summary>
        /// Perform a specific task based on the selection the user made in the menu
        /// </summary>
        /// <param name="userInput">The user input</param>
        protected static void ProcessUserInput(string userInput)
        {
            if (CommandList.Contains(userInput.ToLower()))                                  // Test if user input is in command list
            {
                userInput = userInput.ToLower();                                            // Add support for case insensitivity

                switch (userInput)
                {
                    case "print":
                        
                        if (myList.Count > 0)
                        {
                            Console.WriteLine("The following items are in the list:");

                            for (int i = 0; i < myList.Count; i++)                          // Print list
                            {
                                Console.WriteLine(myList.GetData(i));
                            }
                        }
                        else
                        {                                                                   // If the list is empty, inform the user
                            Console.WriteLine("There is nothing to print, the list is empty");
                        }                        

                        Console.WriteLine();

                        break;
                    case "count":                                                           // Print the number of elements in the list
                        Console.WriteLine("There are currently " + myList.Count + " items in the list\n");

                        break;
                    case "clear":                                                           // Clear the list
                        Console.WriteLine("The list has been cleared\n");

                        myList.Clear();

                        break;
                    case "remove":                                                          // Remove an element from the list
                        Console.WriteLine("A random element has been removed\n");

                        myList.Remove(myRandom.Next(0, myList.Count));

                        break;
                    case "backwards":                                                       // Display the list in reverse order
                        Console.WriteLine("The following elements are in the list (reversed)");

                        myList.PrintReversed();

                        Console.WriteLine();

                        break;
                    case "scramble":                                                        // Scramble the elements in the list
                        myList.Insert(myList.Remove(myRandom.Next(0, myList.Count)), myRandom.Next(0, myList.Count));

                        Console.WriteLine("A random element has been moved to a new location\n");

                        break;
                }
            }
            else
            {
                myList.Add(userInput);                                                      // Add the input to the list
                Console.WriteLine("\"" + userInput + "\" has been added to the list\n");
            }
        }
    }
}
