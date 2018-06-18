using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DateTimeexer
{
	class Program
	{
		static void Main(string[] args)
		{

			Console.WriteLine("It is currently: {0}", DateTime.Now);
			Console.WriteLine("Enter a number to see what time it will be from the current time");
			int num = Convert.ToInt32(Console.ReadLine());
			TimeSpan hours = new TimeSpan(num, 0 , 0);
			DateTime time = DateTime.Now + hours;
			Console.WriteLine("It will be {0} in {1} hours" , time , num);
			Console.ReadLine();
		}
	}
}
