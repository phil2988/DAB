using System;
using System.Linq;

namespace DAB_3_Solution_Grp3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            DbHandler dbHandler = new DbHandler();
            dbHandler.Seed();
         
            // Get all societies sorted by their activity
            Console.WriteLine("All Societies sorted by their activity: \n");

            var societiesCollection = dbHandler.GetCollection<Society>("Societies");
            var societies = dbHandler.GetData<Society>(societiesCollection);

            societies.OrderBy(s => s.Activity.ActivityName).ToList();
            foreach (var society in societies)
            {
                Console.WriteLine("Society with cvr \"{0}\" has activity \"{1}\"", 
                    society.Cvr, 
                    society.Activity.ActivityName
                );
            }
            Console.WriteLine();

            // Get a list of all booked rooms
            var roomsCollection = dbHandler.GetCollection<Room>("Rooms");
            var rooms = dbHandler.GetData<Room>(roomsCollection);

            foreach (var room in rooms)
            {
                if(room.RoomBookings != null)
                {
                    foreach (var booking in room.RoomBookings)
                    {
                        Console.WriteLine("Chairman {0} has booked room {1} from {2} to {3}",
                            booking.BookedBy.Name,
                            room.RoomNumber,
                            booking.BookingStart,
                            booking.BookingEnd);
                    }
                }
            }
            Console.WriteLine();

            foreach (var society in societies)
            {
                Console.WriteLine("Chairman {0} is booking on behalf of society {1}",
                society.ChairmanName, society.Cvr);
            }
        }
    }
}
