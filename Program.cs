using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            string path = Environment.CurrentDirectory + @"\list.txt";
            while (true)
            {
                if (File.Exists(path))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Showing items from list created on: " + File.GetCreationTime(path));
                    Console.WriteLine("\nYour items");
                    Console.ForegroundColor = ConsoleColor.White;
                    list = File.ReadAllLines(path).ToList();
                    if (list.Count() < 1) Console.WriteLine("\nNo items in your list!");
                    for (int i = 1; i < list.Count() + 1; i++)
                    {
                        Console.WriteLine("{0}. {1}", i, list[i - 1].ToUpper());
                    }
                    Console.WriteLine("\nPress Enter to add items or");
                    Console.Write("write 'delete' to start new list: ");
                    string input = Console.ReadLine().ToLower().Trim();
                    if (input == "delete") { File.Delete(path); list.Clear(); continue; }
                    else if (!String.IsNullOrWhiteSpace(input)) { Console.WriteLine("Invalid input!"); Console.ReadKey(); continue; }
                }
                else Console.WriteLine("Invalid filepath!");

                while (true)
                {
                    string input;
                    Console.Clear();
                    if (list.Count() < 1) Console.WriteLine("Your list is empty!\n");
                    Console.Write("Enter new item (blank to return): ");
                    input = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(input)) { File.WriteAllLines(path, list); break; }
                    list.Add(input);
                } 
            }
        }
    }
}

