using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment06
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the connection object
            OleDbConnection conn = new OleDbConnection();

            // Set the connection string
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Uver\Documents\NUIG\Semester 2\CT546 .NET Programming\Assignment 06\Assignment06\Assignment06\ParkingDB.accdb;
Persist Security Info=False;";

            // Open a connection
            conn.Open();

            // Create a command object
            OleDbCommand command = new OleDbCommand();

            // Connect the connection to the command object
            command.Connection = conn;

            // A function for printing the DB
            selectAllPrinter(command);

            //Change commandText for insert, execute and print
            command.CommandText = "INSERT into ParkingTable values (4, 'Nissan Micra', '98LS4482', 'John Smith', 5)";
            Console.WriteLine("Inserted: " + command.ExecuteNonQuery() +" record");
            selectAllPrinter(command);

            //Change commandText for update, execute and print
            command.CommandText = "UPDATE ParkingTable SET Vehicle_Model='Subaru Legacy', Registration='05C90876' where Student_ID=4";
            Console.WriteLine("Inserted: " + command.ExecuteNonQuery() + " record");
            selectAllPrinter(command);

            //Delete the 4th inserted record so the program is ready to go the next time
            command.CommandText = "DELETE FROM ParkingTable where Student_ID=4";
            Console.WriteLine("Deleted: " + command.ExecuteNonQuery() +" record");

            // Close the connection
            conn.Close();
            Console.ReadKey();
        }

        static void selectAllPrinter(OleDbCommand command)
        {
            command.CommandText = "SELECT * FROM ParkingTable";
            OleDbDataReader reader = command.ExecuteReader();
            // Print the contents of the reader
            while (reader.Read())
            {
                Console.WriteLine(reader[0].ToString() + "\t" +
                    reader[1].ToString() + "\t" +
                    reader[2].ToString() + "\t" +
                    reader[3].ToString() + "\t" +
                    reader[4].ToString());
            }
            reader.Close();
        }
    }
}
