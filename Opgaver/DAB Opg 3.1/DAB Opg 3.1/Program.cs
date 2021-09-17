using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAB_Opg_3._1
{
    class Program
    {
         static void Main(string[] args)
        {
            DBHandler db = new DBHandler();

            db.ServerTest();
            

        }
    }
}
