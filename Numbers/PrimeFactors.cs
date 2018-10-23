 /*
**Program for decomposition  natural numbers into prime factors
*/
using System;

namespace PrimeFactors
{
	class Program
	{
		public static void Main()
		{
			//decoration program description
			Console.BackgroundColor = ConsoleColor.Green;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.WriteLine("*******************************************");
			Console.WriteLine("*****The number factorization  program*****");
			Console.WriteLine("*****                                 *****");
			Console.WriteLine("*****Program for decomposition natural*****");
			Console.WriteLine("*****numbers into    prime     factors*****");
			Console.WriteLine("*******************************************");
			Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
			
			//infinite loop until user enters 0
			while(true)
			{
				Console.Write("Enter a natural number greater than 1 >> ");
				long n = long.Parse(Console.ReadLine());
				Console.Write(n);
				if(n == 0) return;
				Decomposition(n);
				Console.WriteLine("<<Enter 0 to exit>>");
			}
		}
		public static void Decomposition(long n)
		{
			Console.Write("\n" + n + " = ");
			for(int i = 2; i <= n; i++)
			{
				while(n % i == 0)
				{
					Console.Write(i);
					n /= i;
					if(n >= i) Console.Write("*");
				}
			}
			Console.Write("\n\n");
		}
	}
}
