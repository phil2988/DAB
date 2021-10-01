using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAB_assignment_modeling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing Database...");

            SqlController sqlController = new("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MunicipalityDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            string c = "_name";
            string p = "BoAndersen";
            sqlController.insertData("Member", c, p);
            
        }
    }

    public class SqlController
    {
        string _connString;
        SqlConnection con = new SqlConnection();
        public SqlController(string connString)
        {
            _connString = connString;
        }

        public void insertData(string tableName = "", string colums = "", string parameters = "")
        {
            Console.WriteLine("Connecting to database...");
            SqlConnection conn = new SqlConnection(_connString);
            Console.WriteLine("Connected!");
            Console.WriteLine("Opening for queries...");
            conn.Open();
            Console.WriteLine("Connection is now open!");

            Console.WriteLine("Preparing query command...");
            SqlCommand command = new SqlCommand();

            //"INSERT INTO klant(klant_id,naam,voornaam) VALUES(@param1,@param2,@param3)"
            string query = ("INSERT INTO " + tableName);
            query += "(" + colums + ") ";
            query += ("VALUES('" + parameters + "')");

            //command.Parameters.Add("INSERT INTO " + tableName + "(" + colums + ") VALUES(" + parameters + ")");

            command.Connection = conn;
            command.CommandText = query;

            var err = command.ExecuteNonQuery();

            Console.WriteLine("Attempted to send query: " + command.CommandText.ToString() + " With return value: " + err);
            
            conn.Close();
            Console.WriteLine("Closing connection and ending insert...");

        }
    }
}
