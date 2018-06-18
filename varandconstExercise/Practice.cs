using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
	class Person
	{
		public Person(string firstName) : this("joe", "Smith")
		{

		}
		public Person(string firstName, string lastName)
		{
			firstName = "Bob";
			lastName = "Hopkins";
			var type = "Six string";
			const string guitar = "Fender";
		}

		
		
		
	}
}
