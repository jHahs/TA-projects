using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExceptionHandling2
{
	class Program
	{
		static void Main()
		{
			Program:
			try
			{
				bool validAge = false;
				int age = 0;
				while (!validAge)
				{
					Console.WriteLine("Please enter your age.");
					validAge = int.TryParse(Console.ReadLine(), out age);
					if (age == 0)
					{
						throw new ZeroException();
					}
					else if (age < 0)
					{
						throw new NegativeException();
					}

				}
				var currentyear = DateTime.Now.Year.ToString();
				int birth = Int32.Parse(currentyear) - age;
				Console.WriteLine("You were born in the year {0}", birth);
				Console.ReadLine();
			}
			catch(ZeroException)
			{
				Console.WriteLine("Please enter a number higher than zero");
				goto Program;
			}
			catch(NegativeException)
			{
				Console.WriteLine("Please enter a number that is not a negative");
				goto Program;
			}
			catch(Exception)
			{
				Console.WriteLine("Please enter a Whole number");
				goto Program;
			}
			Console.ReadLine();

			//Console.WriteLine("Please enter your age.");
			//int age = Convert.ToInt32(Console.ReadLine());
			//var currentyear = DateTime.Now.Year.ToString();
			//int birth = Int32.Parse(currentyear) - age;
			//Console.WriteLine("You were born in the year {0}", birth);
			//Console.ReadLine();
		}
	}	
}
