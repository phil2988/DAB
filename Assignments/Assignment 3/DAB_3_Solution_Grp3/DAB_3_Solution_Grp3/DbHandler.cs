using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB_3_Solution_Grp3
{


    class DbHandler
    {
        // Db identification
        private readonly MongoClient client;
        private readonly IMongoDatabase database;
        private readonly string DbName = "DabAssignment3";

        // Collections
        private IMongoCollection<Municipality> Municipalities;
        private IMongoCollection<Society> Societies;
        private IMongoCollection<Activity> Activities;
        private IMongoCollection<Member> Members;
        private IMongoCollection<Key> Keys;
        private IMongoCollection<Room> Rooms;
        private IMongoCollection<RoomProperty> RoomProperties;
        private IMongoCollection<RoomBooking> RoomBookings;

        private readonly string connString = "mongodb+srv://phil2988:Phillip1@i4dab-database.vubpg.mongodb.net/I4DAB-Database?retryWrites=true&w=majority";

        public DbHandler()
        {
            // Setup connection
            Console.WriteLine("Creating MongoDb Client...\n");
            client = new MongoClient(connString);

            // Reset data
            Console.WriteLine("Fetching database \"" + DbName + "\"...\n");
            database = client.GetDatabase(DbName);

            // Set Reference to collections
            Console.WriteLine("Saving references to collections...\n");
            Municipalities = database.GetCollection<Municipality>("Municipalities");
            Societies = database.GetCollection<Society>("Societies");
            Activities = database.GetCollection<Activity>("Activities");
            Members = database.GetCollection<Member>("Members");
            Keys = database.GetCollection<Key>("Keys");
            Rooms = database.GetCollection<Room>("Rooms");
            RoomProperties = database.GetCollection<RoomProperty>("RoomProperties");
            RoomBookings = database.GetCollection<RoomBooking>("RoomBookings");

            Console.WriteLine("Setup Complete!");
        }

        public static void Insert<T>(IMongoCollection<T> collection, T input)
        {
            Console.WriteLine("Inserting " + input.ToString() + "...\n");

            Task.Run(() =>
            {
                collection.InsertOne(input);
            }).Wait();

            Console.WriteLine("Finished inserting!\n");
        }

        public void Seed()
        {
            Console.WriteLine("Clearing collections...");

            foreach (var col in database.ListCollectionNames().ToList())
            {
                database.DropCollection(col);
            }

            Console.WriteLine("Seeding Database...\n");

            Insert<Municipality>(Municipalities,
                new Municipality
                {
                    MunicipalityId = Guid.NewGuid()
                }
            );

            Insert<Society>(Societies, 
                new Society
                {
                    SocietyId = Guid.NewGuid(),
                    Cvr = 19582858,
                    Adress = "Adress",
                    ChairmanName = ""
                }
            );

            Insert<Activity>(Activities,
                new Activity
                {
                    ActivityId = Guid.NewGuid(),
                    ActivityName = "Chess"
                }
            );

            Insert<Member>(Members,
                new Member
                {
                    MemberId = Guid.NewGuid(),
                    Name = "Thomas Jonson",
                    Adress = "Manchester Street 231",
                    Cpr = "1232451052",
                    IsChairman = false,
                    PhoneNumber = "27756235",
                    PassportNumber = "112452124"
                }
            );

            Insert<Key>(Keys,
                new Key
                {
                    KeyId = Guid.NewGuid()
                }
            );

            Insert<Room>(Rooms,
                new Room
                {
                    RoomKey = 1,
                    RoomAdress = "Old Werner alé 21",
                    MaxMembers = 15,
                    RoomAvailabilityStart = new TimeSpan(9, 0, 0),
                    RoomAvailabilityEnd = new TimeSpan(15, 0, 0)
                }
            );

            Insert<RoomProperty>(RoomProperties,
                new RoomProperty
                {
                    PropertyId = Guid.NewGuid(),
                    Chairs = true,
                    CoffeeMachine = true,
                    SoccerGoals = false,
                    SoundSystem = true,
                    Tables = false,
                    Toilet = false,
                    Water = false,
                    Whiteboard = true,
                    Wifi = true
                }
            );

            Insert<RoomBooking>(RoomBookings,
                new RoomBooking
                {
                    BookingId = Guid.NewGuid(),
                    BookedBy = new Member { },
                    BookingStart = new DateTime(2021, 11, 30, 12, 0, 0),
                    BookingEnd = new DateTime(2021, 11, 30, 15, 0, 0)
                }
            );
        }


        #region Tables

        internal class Municipality
        {
            [BsonId]
            public Guid MunicipalityId { get; set; }
            //public Guid SocietyId { get; set; }
        }
        internal class Society
        {
            public Guid SocietyId { get; set; }
            public int Cvr { get; set; }
            public string Adress { get; set; }
            public string ChairmanName { get; set; }
        }
        internal class Activity
        {
            public Guid ActivityId { get; set; }
            public string ActivityName { get; set; }
        }
        internal class Member
        {
            public Guid MemberId { get; set; }
            public string Name { get; set; }
            public string Adress { get; set; }
            public string Cpr { get; set; }
            public bool IsChairman { get; set; }
            public string PhoneNumber { get; set; }
            public string PassportNumber { get; set; }
        }
        internal class Key
        {
            public Guid KeyId { get; set; }
        }
        internal class Room
        {
            public int RoomKey { get; set; }
            public string RoomAdress { get; set; }
            public int MaxMembers { get; set; }
            public TimeSpan RoomAvailabilityStart { get; set; }
            public TimeSpan RoomAvailabilityEnd { get; set; }
        }
        internal class RoomProperty
        {
            public Guid PropertyId { get; set; }
            public bool CoffeeMachine { get; set; }
            public bool Water { get; set; }
            public bool Toilet { get; set; }
            public bool Chairs { get; set; }
            public bool Wifi { get; set; }
            public bool Whiteboard { get; set; }
            public bool SoccerGoals { get; set; }
            public bool Tables { get; set; }
            public bool SoundSystem { get; set; }
        }
        internal class RoomBooking
        {
            public Guid BookingId { get; set; }
            public DateTime BookingStart { get; set; }
            public DateTime BookingEnd { get; set; }
            public Member BookedBy { get; set; }
        }
        #endregion Tables
    }
}
