using System;

namespace DAB_3_Solution_Grp3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            DbHandler dbHandler = new DbHandler();
            dbHandler.Seed();

            //Console.WriteLine("Hello World!");
        }
    }
}
