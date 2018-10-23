//PI with Nth digit
//E  with Nth digit
using System;


namespace PIandE
{
	class Program
	{
		public static void Main()
		{
			Console.Write("Specify the accuracy: ");
		  int n = int.Parse(Console.ReadLine());
      //formatted output of PI
			Console.Write("The PI number with specified accuracy: ");
			Console.WriteLine("PI={0:F" + n + "}", Math.PI);
      //formatted output of E
			Console.Write("The E number with specified accuracy:: ");
			Console.WriteLine("E ={0:F" + n + "}", Math.E);
      
			Console.ReadKey();
		}
	}
}
