// See https://aka.ms/new-console-template for more information
using System;

namespace Hello
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Привет, " + name);
        }
    }
}
