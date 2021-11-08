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
            List<Society> members = new List<Society>();
            List<Society> societies = new List<Society>();
            List<Room> rooms = new List<Room>();

            DbHandler<Room> dbRoomHandler = new DbHandler<Room>(new au653164Context());
            DbHandler<Society> dbSocietyHandler = new DbHandler<Society>(new au653164Context());
            DbHandler<Member> dbMemberHandler = new DbHandler<Member>(new au653164Context());


        programStart:

            Console.WriteLine("Press 1 to get all information about rooms in this Municipality");
            Console.WriteLine("Press 2 to get all Societies by their activities");

            var inp = Console.ReadKey().Key;
            Console.WriteLine();
            switch (inp)
            {
                case ConsoleKey.D1:
                    rooms = dbRoomHandler.GetTable();

                    //foreach (var room in rooms)
                    //{
                    //    if (room.BookedByName == null)
                    //        Console.WriteLine("Adress of Room with id {0} is {1} and its room number is {2}", room.RoomId, room.LocationAdress, room.RoomKey);

                    //}

                    Console.WriteLine();
                    goto programStart;

                case ConsoleKey.D2:

                    foreach(var society in societies)
                    {
                        Console.WriteLine("In society {0} ");
                    }

                    Console.WriteLine();
                    goto programStart;
                default:
                    Console.WriteLine("Input was not valid...");
                    goto programStart;
            }
        }
    }
}
