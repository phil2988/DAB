using DAB_Assignment_2_v2.Architecture;
using System;

namespace DAB_Assignment_2_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseContext dbcontext = new();
            DbHandler dbhandler = new(dbcontext);

            dbhandler.SeedData();

            Console.WriteLine("Hello World!");
        }
    }
}
