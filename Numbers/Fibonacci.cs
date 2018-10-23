using System;
/*
   Fibonacci Sequence - Enter a number and have the program 
   generate the Fibonacci sequence to that number or to the Nth number
   
   Jacques Philippe Marie Binet formula expresses explicitly the value 
   of Fn as a function of n:
   
   Fn = (pow((1 + sqrt(5))/2, n) - pow((1 - sqrt(5))/2, n))/sqrt(5))
*/
namespace Fibonacci
{
	class Program
	{
		public static void Main()
		{
			Console.Write("Enter a number to generate \n the Fibonacci sequence to the Nth number: ");
			int n = int.Parse(Console.ReadLine());
			if (n >= 2) Fib(n);
			else
			{
				Console.BackgroundColor = ConsoleColor.Red;
				Console.WriteLine("To calculate Fibonacci sequence you have to Enter a number bigger than 2!");
			}
			Console.ReadKey();
		}
		//Counting the Fibonacci number using the Binet formula
		public static void Fib(int n)
		{
			double f1 = Math.Pow((1 + Math.Sqrt(5))/2, n);
			double f2 = Math.Pow((1 - Math.Sqrt(5))/2, n);
			double Fdouble = (f1 - f2)/Math.Sqrt(5);
			int F = (int)Fdouble;
			Console.WriteLine(F);
		}
	}
}
