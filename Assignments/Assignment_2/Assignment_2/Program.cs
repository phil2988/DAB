using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Assignment_2.Tables;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> members = new List<Member>();
            DbHandler<Member> dbHandler = new DbHandler<Member>(new au653164Context());
            
            foreach (var m in dbHandler.GetTable())
            {
                members.Add(m);
            }
            members = dbHandler.GetTable();

            Console.WriteLine("First member in database is: " + members[0].Name);
        }
    }
}
