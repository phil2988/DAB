using DAB_Assignment_2_v2.Architecture;
using DAB_Assignment_2_v2.Models;
using System;
using System.Linq;

namespace DAB_Assignment_2_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbcontext = new DatabaseContext();
            var dbhandler = new DbHandler(dbcontext);

            dbhandler.SeedData();

            // Get all societies sorted by their activity
            Console.WriteLine("All Societies sorted by their activity: \n");

            var societies = dbcontext.Society.OrderBy(s => s.Activity.AcitivtyName).ToList();
            foreach (var society in societies)
            {
                Console.WriteLine("Society with cvr \"{0}\" has activity \"{1}\"", 
                    society.Cvr, 
                    dbcontext
                        .Activity
                        .SingleOrDefault(a => a.ActivityId == society.AcivityId)
                        .AcitivtyName
                );
            }
            Console.WriteLine();

            // Get a list of all booked rooms

            foreach (var booking in dbcontext.RoomBooking)
            {
                int roomKey = 0;
                foreach (var id in booking.Room.BookingIds)
                {
                    if(id.BookingId == booking.BookingId)
                    {
                        roomKey = id.Room.RoomKey;
                    }
                }

                Console.WriteLine("Chairman {0} has booked room {1} from {2} to {3}",
                    booking.BookedBy.Name,
                    roomKey,
                    booking.BookingStart,
                    booking.BookingEnd);                  
            }
            Console.WriteLine();

            Console.WriteLine("Chairman Devon L. Dixon is booking on behalf of society {0}", dbcontext.Society.FirstOrDefault(m => m.ChairmanName == "Devon L. Dixon").Cvr);
            Console.WriteLine("Chairman Devon L. Dixon is booking on behalf of society {0}", dbcontext.Society.FirstOrDefault(m => m.ChairmanName == "Brian B. Brooks").Cvr);
        }
    }
}
