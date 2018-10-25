using System;

namespace Tile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("*************************************");
            Console.WriteLine("*Program calculate the total cost of*");
            Console.WriteLine("*tile it would take to cover a floor*");
            Console.WriteLine("*************************************");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write("Enter the cost per square meter >> ");
            double cost = double.Parse(Console.ReadLine());
            Console.Write("Enter the width of the floor  >> ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Enter the height of the floor >> ");
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine($"The total cost is {width * height * cost} for {width * height} square meter");

            Console.WriteLine("Type ENTER to exit ...");
            Console.ReadKey();
        }
    }
}
