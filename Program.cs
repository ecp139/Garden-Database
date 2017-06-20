using System;
using Mono.Data.Sqlite;
using System.Data;

namespace Garden
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello what are the dimensions of your raised garden bed in feet?");
			Console.WriteLine("What is the length of the bed?");
			double length = Convert.ToDouble(Console.ReadLine());

			Console.WriteLine("What is the width of the bed?");
			double width = Convert.ToDouble(Console.ReadLine());

			double area = length * width;
			Console.WriteLine($"The area of your raised bed is {area} square feet.");
			Console.WriteLine();

			Calculation db = new Calculation();
			Console.WriteLine("Plants can be planted in the following amounts.");
			Console.WriteLine();

			db.display_table();

			Console.WriteLine();

			string replant = "y";

			while (replant == "y")
			{
				Console.WriteLine("Do you want to plant Basil, Radishes or Sweet Potatoes?");

				db.plant_choice(area);

				Console.WriteLine("Would you like to plant something else?  Type (y)es or (n)o.");

				replant = Console.ReadLine().ToLower();

				if (replant == "n")
				{
					Console.WriteLine("Have a nice day!");
				}
			}
		}
	}
}
