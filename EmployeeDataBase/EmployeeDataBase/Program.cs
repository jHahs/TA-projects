using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EmployeeDataBase
{
	class Program
	{
		static void Main(string[] args)
		{
			retry:
			try
			{


				using (var db = new EmployeeContext())
				{
					Console.WriteLine("Welcome to employee entry, would to you like to add a new employee?");
					string userInput = Console.ReadLine().ToLower();
					if (userInput == "yes" || userInput == "yeah")
					{
						Console.WriteLine("Enter employees first name");
						string fname = Console.ReadLine().ToUpper();
						Console.WriteLine("Enter employees last name");
						string lname = Console.ReadLine().ToUpper();
						Console.WriteLine("Enter employees current position");
						string position = Console.ReadLine().ToUpper();
						Console.WriteLine("Enter date of hire. Enter as mm/dd/yyyy");
						DateTime doh = Convert.ToDateTime(Console.ReadLine());
						Employee employee = new Employee();
						employee.FirstName = fname;
						employee.LastName = lname;
						employee.Position = position;
						employee.DoH = doh;
						db.Employees.Add(employee);
						db.SaveChanges();

						var query = from c in db.Employees orderby c.DoH select c;

						Console.WriteLine("Current employees in company:");
						foreach (var person in query)
						{
							Console.WriteLine("Full Name : {0} {1} |  Position : {2} | DoH : {3} ", person.FirstName, person.LastName, person.Position, person.DoH);
						}

						Console.WriteLine("Press any key to exit application");
						Console.ReadKey();
			


					}
					else if (userInput == "no")
					{
						Console.WriteLine("Goodbye");
						Console.ReadLine();
						return;
					}
				}
			}
			catch (FormatException)
			{
				Console.WriteLine("Please Write Date as mm/dd/yyyy");
				goto retry;
			}
		}
	}

	public class Employee
	{
		public int EmployeeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Position { get; set; }
		public DateTime DoH { get; set; }

		
	}

	public class EmployeeContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }
	}


}
