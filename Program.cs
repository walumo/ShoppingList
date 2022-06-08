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
            string path = @"C:\Users\MiikkaHakulinen\source\repos\ShoppingList\list.txt";
            while (true)
            {
                if (File.Exists(path))
                {
                    Console.Clear();
                    Console.WriteLine("Your items");
                    list = File.ReadAllLines(path).ToList();
                    for (int i = 1; i < list.Count() + 1; i++)
                    {
                        Console.WriteLine("{0}. {1}", i, list[i - 1].ToUpper());
                    }
                    Console.Write("Press any key to add items: ");
                    Console.ReadKey();
                }
                else Console.WriteLine("Invalid filepath!");

                while (true)
                {
                    string input;
                    Console.Clear();
                    Console.Write("Enter new item (blank to return): ");
                    input = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(input)) { File.WriteAllLines(path, list); break; }
                    list.Add(input);
                } 
            }
        }
    }
}

