using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAB_Opg_3._1
{
    class DBHandler
    {
        public SqlConnection connection;
        readonly string dbString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=""C:\Users\phill\Desktop\skole\DAB\Opgaver\DAB Opg 3.1\DAB Opg 3.1\Database1.mdf""; Integrated Security=True";
        public DBHandler()
        {
            connection = new SqlConnection(dbString);

        }

        public void ServerTest()
        {
            connection.Open();
            Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
            Console.WriteLine("State: {0}", connection.State);
            connection.Close();
        }

        public void ReadCustomerId()
        {
            string queryString = "SELECT customerId FROM Order;";

            using (SqlConnection connection = new SqlConnection(connection))
                { 
            
                }

            }
        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }

        public SqlCommand CreateCommand(string c)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = c;
            sqlCommand.Connection = connection;
            return sqlCommand;
        }
        public void Open()
        {
            connection.Open();
        }
        public void Close()
        {
            connection.Close();
        }
    }
}
