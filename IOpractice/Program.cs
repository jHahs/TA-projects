using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace IOpractice
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter a number");
			string num = Console.ReadLine();
			File.WriteAllText(@"C:\Users\snosh\Desktop\Number\log.txt", num);
			string text = File.ReadAllText(@"C:\Users\snosh\Desktop\Number\log.txt");
			Console.WriteLine("Here is your number logged to a file...");
			Console.WriteLine(text);
			Console.ReadLine();
		}
	}
}
