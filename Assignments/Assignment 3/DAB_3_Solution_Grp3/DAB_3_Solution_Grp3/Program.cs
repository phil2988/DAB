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

            // Get a list of all rooms and their adress

            var roomsCollection = dbHandler.GetCollection<Room>("Rooms");
            var rooms = dbHandler.GetData<Room>(roomsCollection);

            Console.WriteLine("Getting municpality information: Room(adresses)");
            foreach (var room in rooms)
            {
                Console.WriteLine("Adress {0} with room {1}", room.RoomAdress, room.RoomNumber);
            }

            // Get all societies sorted by their activity
            Console.WriteLine();
            Console.WriteLine("Getting all Societies sorted by their activity");

            var societiesCollection = dbHandler.GetCollection<Society>("Societies");
            var societies = dbHandler.GetData<Society>(societiesCollection);

            societies.OrderBy(s => s.Activity.ActivityName).ToList();
            foreach (var society in societies)
            {
                Console.WriteLine("Society with cvr \"{0}\" at adress \"{1}\" has activity \"{2}\" managed by chairman \"{3}\"", 
                    society.Cvr, 
                    society.Adress,
                    society.Activity.ActivityName,
                    society.ChairmanName
                );
            }
            Console.WriteLine();

            // Get a list of all booked rooms
            Console.WriteLine();
            Console.WriteLine("Getting all booked rooms");

            foreach (var room in rooms)
            {
                if(room.RoomBookings != null)
                {
                    foreach (var booking in room.RoomBookings)
                    {
                        Console.WriteLine("Room \"{0}\" at adress \"{1}\" is booked by society \"{2}\" on behalf of chairman \"{3}\" from \"{4}\" to \"{5}\"",
                            room.RoomNumber, room.RoomAdress, societies.Find(s => s.ChairmanName == booking.BookedBy.Name).Cvr,
                            booking.BookedBy.Name, booking.BookingStart, booking.BookingEnd);
                    }
                }
            }

            // Get a list of all future bookings with key responsible
            Console.WriteLine();
            Console.WriteLine("Getting all bookins with key responsible");

            foreach (var room in rooms)
            {
                if (room.RoomBookings != null)
                {
                    foreach (var booking in room.RoomBookings)
                    {
                        Console.WriteLine("Member {0} is keyresponsible for booking of room {1} at adress {2} on {3}",
                            booking.BookedBy,
                            room.RoomNumber,
                            room.RoomAdress,
                            booking.BookingStart.Date);
                    }
                }
            }
        }
    }
}
