using System;
using System.Data;
//using System.IO;
using Microsoft.Data.SqlClient;

namespace DAB_assignment_modeling
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlController sqlController = new(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MunicipalityDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlController sqlController = new(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //sqlController.Init();
            string c = "_name";
            string p = "Sanne Andersen, ";
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
        
        //public void Init()
        //{
        //    Console.WriteLine("Initializing database...");
        //    string scrpt = File.ReadAllText(@"C:\Users\Phillip\Desktop\Skole\DAB\Assignments\1_Modeling\DAB assignment modeling\DAB assignment modeling\SQLQuery.sql");
        //    SqlConnection connection = new(_connString);
        //    SqlCommand command = new();

        //    command.CommandText = scrpt;
        //    command.Connection = connection;
        //    command.CommandType = CommandType.Text;
        //    connection.Open();
        //    command.ExecuteNonQuery();
        //    connection.Close();
        //    Console.WriteLine("Database finished initializing!");
        //}

        public void insertData(string tableName = "", string colums = "", string parameters = "")
        {
            Console.WriteLine("Connecting to database...");
            SqlConnection conn = new SqlConnection(_connString);
            Console.WriteLine("Connected!");
            Console.WriteLine("Opening for queries...");
            conn.Open();
            Console.WriteLine("Connection is now open!");

            Console.WriteLine("Preparing query command...");
            SqlCommand command = new();

            string query = ("INSERT INTO " + tableName);
            query += "(" + colums + ") ";
            query += ("VALUES('" + parameters + "')");

            command.Connection = conn;
            command.CommandText = query;

            var err = command.ExecuteNonQuery();

            Console.WriteLine("Attempted to send query: " + command.CommandText.ToString() + " With return value: " + err);
            
            conn.Close();
            Console.WriteLine("Closing connection and ending insert...");

        }
    }
}
