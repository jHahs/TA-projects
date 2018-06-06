using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("Pick a integer to do an operation on:");
			int userinput = Convert.ToInt32(Console.ReadLine());
			int sum = Ops.Addition( userinput);
			int quotient = Ops.Division( userinput);
			int product = Ops.Multiplication( userinput);
			Console.WriteLine("Here is the sum of your integer: " + sum);
			Console.WriteLine("Here is the quotient of your integer: " + quotient);
			Console.WriteLine("Here is the product of your integer: " + product);

			Console.ReadLine();
		}
	}
}
