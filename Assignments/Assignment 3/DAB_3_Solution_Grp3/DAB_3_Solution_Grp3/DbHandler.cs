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

            Console.WriteLine("Setup Complete!\n");
        }

        public static void Insert<T>(IMongoCollection<T> collection, T input)
        {
            Console.WriteLine("Inserting data...\n");

            Task.Run(() =>
            {
                collection.InsertOne(input);
            }).Wait();

            Console.WriteLine("Finished inserting!\n");
        }

        public static void Insert<T>(IMongoCollection<T> collection, List<T> inputs)
        {
            Console.WriteLine("Inserting data... \n");

            foreach (var obj in inputs)
            {
                Task.Run(() =>
                {
                    collection.InsertOne(obj);
                }).Wait();
            }

            Console.WriteLine("Finished inserting!\n");
        }

        public IMongoCollection<T> GetCollection<T>(string collection)
        {
            return database.GetCollection<T>(collection);
        }

        public List<T> GetData<T>(IMongoCollection<T> collection) 
        {
            return collection.Find(_ => true).ToList();
        }

        public void Seed()
        {
            Console.WriteLine("Clearing collections...\n");

            foreach (var col in database.ListCollectionNames().ToList())
            {
                database.DropCollection(col);
            }

            Console.WriteLine("Seeding Database...\n");

            Insert<Activity>(Activities, new List<Activity> 
            {
                new Activity
                {
                    ActivityName = "Chess"
                },
                new Activity
                {
                    ActivityName = "Soccer"
                },
                new Activity
                {
                    ActivityName = "Golf"
                }
            });

            Insert<Key>(Keys, new List<Key>{
                new Key { RoomAdress = "920 Dawson Drive", RoomNumber = 1},
                new Key { RoomAdress = "920 Dawson Drive", RoomNumber = 2},
                new Key { RoomAdress = "920 Dawson Drive", RoomNumber = 3},
                new Key { RoomAdress = "920 Dawson Drive", RoomNumber = 4},
                new Key { RoomAdress = "1553 Cheshire Road", RoomNumber = 1},
                new Key { RoomAdress = "1553 Cheshire Road", RoomNumber = 2},
                new Key { RoomAdress = "1553 Cheshire Road", RoomNumber = 3},
                new Key { RoomAdress = "77 Arron Smith Drive", RoomNumber = 1},
            });

            Insert<Member>(Members, new List<Member>
            {
                new Member
                {
                    Name = "Eric K. Finkle",
                    Adress = "3796 Saints Alley",
                    Cpr = "1232451052",
                    IsChairman = true,
                    PhoneNumber = "27756235",
                    PassportNumber = "112452124",
                    Keys = Keys.Find(k => k.RoomAdress == "920 Dawson Drive").ToList()
                },
                new Member
                {
                    Name = "Luis P. Green",
                    Adress = "2348 Saint Marys Avenue",
                    Cpr = "2868283960",
                    IsChairman = true,
                    PhoneNumber = "66234256",
                    PassportNumber = "621357894",
                    Keys = Keys.Find(k => k.RoomAdress == "1553 Cheshire Road").ToList()
                },
                new Member
                {
                    Name = "Gerald M. Kahl",
                    Adress = "1445 Marshall Street",
                    Cpr = "5485231658",
                    IsChairman = true,
                    PhoneNumber = "85625369",
                    PassportNumber = "152485695",
                    Keys = Keys.Find(k => k.RoomAdress == "77 Arron Smith Drive").ToList()
                },
                new Member
                {
                    Name = "John E. Langlois",
                    Adress = "2158 Little Street",
                    Cpr = "8521645872",
                    IsChairman = false,
                },
                new Member
                {
                    Name = "James E. Brotherton",
                    Adress = "3854 Linda Street",
                    Cpr = "6659482154",
                    IsChairman = false,
                },
                new Member
                {
                    Name = "Ben S. Alegria",
                    Adress = "2125 Richland Avenue",
                    Cpr = "1145788545",
                    IsChairman = false,
                }
            });

            Insert<Society>(Societies, new List<Society>
            {
                new Society
                {
                    Cvr = 11111111,
                    Adress = "3939 Dark Hollow Road",
                    ChairmanName = "Eric K. Finkle",
                    Activity = Activities.Find(a => a.ActivityName == "Golf").FirstOrDefault(),
                    Members = new List<Member>()
                    {
                        Members.Find(m => m.Name == "Eric K. Finkle").FirstOrDefault(),
                        Members.Find(m => m.Name == "John E. Langlois").FirstOrDefault(),
                        Members.Find(m => m.Name == "Ben S. Alegria").FirstOrDefault()
                    }
                },
                new Society
                {
                    Cvr = 22222222,
                    Adress = "3963 Timberbrook Lane",
                    ChairmanName = "Luis P. Green",
                    Activity = Activities.Find(a => a.ActivityName == "Soccer").FirstOrDefault(),
                    Members = new List<Member>()
                    {
                        Members.Find(m => m.Name == "Luis P. Green").FirstOrDefault(),
                        Members.Find(m => m.Name == "James E. Brotherton").FirstOrDefault(),
                        Members.Find(m => m.Name == "Ben S. Alegria").FirstOrDefault()
                    }
                },
                new Society
                {
                    Cvr = 33333333,
                    Adress = "2204 Hillview Street",
                    ChairmanName = "Gerald M. Kahl",
                    Activity = Activities.Find(a => a.ActivityName == "Chess").FirstOrDefault(),
                    Members = new List<Member>()
                    {
                        Members.Find(m => m.Name == "Gerald M. Kahl").FirstOrDefault(),
                        Members.Find(m => m.Name == "John E. Langlois").FirstOrDefault(),
                        Members.Find(m => m.Name == "James E. Brotherton").FirstOrDefault()
                    }
                }
            });

            Insert<Municipality>(Municipalities, new Municipality {
                    Societies = new List<Society>
                    {
                        Societies.Find(s => s.Cvr == 11111111).FirstOrDefault(),
                        Societies.Find(s => s.Cvr == 22222222).FirstOrDefault(),
                        Societies.Find(s => s.Cvr == 33333333).FirstOrDefault()
                    }
                });

            Insert<Room>(Rooms, new List<Room>
            {
                new Room
                {
                    RoomNumber = 1,
                    RoomAdress = "920 Dawson Drive",
                    MaxMembers = 15,
                    RoomAvailabilityStart = new TimeSpan(9, 0, 0),
                    RoomAvailabilityEnd = new TimeSpan(15, 0, 0),
                    RoomBookings = new List<RoomBooking>()
                    {
                        new RoomBooking
                        {
                            BookedBy = Members.Find(m => m.Name == "Eric K. Finkle").FirstOrDefault(),
                            BookingStart = new DateTime(2021, 11, 30, 12, 0, 0),
                            BookingEnd = new DateTime(2021, 11, 30, 15, 0, 0)
                        }
                    }
                },
                new Room
                {
                    RoomNumber = 2,
                    RoomAdress = "920 Dawson Drive",
                    MaxMembers = 15,
                    RoomAvailabilityStart = new TimeSpan(9, 0, 0),
                    RoomAvailabilityEnd = new TimeSpan(15, 0, 0),
                    RoomBookings = new List<RoomBooking>()
                    {
                        new RoomBooking
                        {
                            BookedBy = Members.Find(m => m.Name == "Eric K. Finkle").FirstOrDefault(),
                            BookingStart = new DateTime(2021, 11, 30, 12, 0, 0),
                            BookingEnd = new DateTime(2021, 11, 30, 15, 0, 0)
                        }
                    }
                },
                new Room
                {
                    RoomNumber = 3,
                    RoomAdress = "920 Dawson Drive",
                    MaxMembers = 15,
                    RoomAvailabilityStart = new TimeSpan(9, 0, 0),
                    RoomAvailabilityEnd = new TimeSpan(15, 0, 0),
                    RoomBookings = new List<RoomBooking>()
                    {
                        new RoomBooking
                        {
                            BookedBy = Members.Find(m => m.Name == "Eric K. Finkle").FirstOrDefault(),
                            BookingStart = new DateTime(2021, 11, 30, 12, 0, 0),
                            BookingEnd = new DateTime(2021, 11, 30, 15, 0, 0)
                        }
                    }
                },
                new Room
                {
                    RoomNumber = 4,
                    RoomAdress = "920 Dawson Drive",
                    MaxMembers = 15,
                    RoomAvailabilityStart = new TimeSpan(9, 0, 0),
                    RoomAvailabilityEnd = new TimeSpan(15, 0, 0)
                },
                new Room
                {
                    RoomNumber = 1,
                    RoomAdress = "1553 Cheshire Road",
                    MaxMembers = 15,
                    RoomAvailabilityStart = new TimeSpan(9, 0, 0),
                    RoomAvailabilityEnd = new TimeSpan(18, 0, 0)
                },
                new Room
                {
                    RoomNumber = 2,
                    RoomAdress = "1553 Cheshire Road",
                    MaxMembers = 15,
                    RoomAvailabilityStart = new TimeSpan(9, 0, 0),
                    RoomAvailabilityEnd = new TimeSpan(18, 0, 0),
                    RoomBookings = new List<RoomBooking>()
                    {
                        new RoomBooking
                        {
                            BookedBy = Members.Find(m => m.Name == "Luis P. Green").FirstOrDefault(),
                            BookingStart = new DateTime(2021, 12, 15, 10, 0, 0),
                            BookingEnd = new DateTime(2021, 12, 15, 17, 0, 0)
                        },
                        new RoomBooking
                        {
                            BookedBy = Members.Find(m => m.Name == "Luis P. Green").FirstOrDefault(),
                            BookingStart = new DateTime(2021, 12, 16, 10, 0, 0),
                            BookingEnd = new DateTime(2021, 12, 16, 17, 0, 0)
                        },
                        new RoomBooking
                        {
                            BookedBy = Members.Find(m => m.Name == "Luis P. Green").FirstOrDefault(),
                            BookingStart = new DateTime(2021, 12, 17, 10, 0, 0),
                            BookingEnd = new DateTime(2021, 12, 17, 17, 0, 0)
                        }
                    }
                },
                new Room
                {
                    RoomNumber = 3,
                    RoomAdress = "1553 Cheshire Road",
                    MaxMembers = 15,
                    RoomAvailabilityStart = new TimeSpan(9, 0, 0),
                    RoomAvailabilityEnd = new TimeSpan(18, 0, 0)
                },
                new Room
                {
                    RoomNumber = 1,
                    RoomAdress = "77 Arron Smith Drive",
                    MaxMembers = 15,
                    RoomAvailabilityStart = new TimeSpan(10, 0, 0),
                    RoomAvailabilityEnd = new TimeSpan(13, 0, 0)
                },
            });

            Insert<RoomProperty>(RoomProperties, new List<RoomProperty>()
            {
                new RoomProperty
                {
                    Chairs = true,
                    CoffeeMachine = true,
                    SoccerGoals = false,
                    SoundSystem = true,
                    Tables = false,
                    Toilet = false,
                    Water = false,
                    Whiteboard = true,
                    Wifi = true
                },
                new RoomProperty
                {
                    Chairs = true,
                    CoffeeMachine = true,
                    SoccerGoals = false,
                    SoundSystem = false,
                    Tables = false,
                    Toilet = true,
                    Water = true,
                    Whiteboard = false,
                    Wifi = true
                },
                new RoomProperty
                {
                    Chairs = false,
                    CoffeeMachine = true,
                    SoccerGoals = true,
                    SoundSystem = true,
                    Tables = true,
                    Toilet = false,
                    Water = true,
                    Whiteboard = false,
                    Wifi = false
                },
            });
        }

    }
}
