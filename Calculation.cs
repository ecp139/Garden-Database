using System;
using Mono.Data.Sqlite;
using System.Data;

namespace Garden
{
	public class Calculation
	{
		
		SqliteConnection connection;
		SqliteCommand command; //defining command variable
		SqliteDataReader reader; //

		public void openDataConnection()
		{

			connection = new SqliteConnection(@"Data Source =/Users/esrapetursson/Desktop/Garden/Garden/garden.sqlite");
			connection.Open();
		}

		public void closeDataConnection()
		{
			connection = new SqliteConnection(@"Data Source =/Users/esrapetursson/Desktop/Garden/Garden/garden.sqlite");
			connection.Close();
		}
		public void display_table()
		{
			openDataConnection();
			SqliteCommand show_info = new SqliteCommand("SELECT * FROM garden", connection);
			SqliteDataReader display = show_info.ExecuteReader();
			while (display.Read())
			{
				Console.Write(display["plant"] + ": ");
				Console.WriteLine(display["per_sq"] + " plants per sq ft");
			}
			closeDataConnection();
		}

		public void plant_choice(double area)
		{
			
			openDataConnection();

			string answer = " ";
			answer = Console.ReadLine().ToLower();

			if (answer == "basil" || answer == "radishes" || answer == "sweet potatoes")
			{
				command = new SqliteCommand($"SELECT * FROM garden WHERE plant = '{answer}'", connection);
				reader = command.ExecuteReader();
			}

			else if (answer != "basil" || answer != "radishes" || answer != "sweet potatoes")
			{
				Console.WriteLine("That is an invalid response.");
				return;
			}

			if (reader.HasRows) //see if rows exist in database if there's nothing in the table, this will not execute
			{
				while (reader.Read())
				{
					double plant_area = area * reader.GetInt32(reader.GetOrdinal("per_sq"));
					plant_area = Math.Floor(plant_area);
					Console.WriteLine("You can plant" + " " + plant_area + " " + reader["plant"] + " plants");
				}
			}

			reader.Close();
			closeDataConnection();
		}
	}
}
