using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;


namespace DAB_3_Solution_Grp3
{


    class DbHandler
    {
        // Db identification
        private readonly MongoClient client;
        private readonly IMongoDatabase database;

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
            client = new MongoClient(connString);
            database = client.GetDatabase("DabAssignment3");
            Municipalities = database.GetCollection<Municipality>("Municipalities");
            Societies = database.GetCollection<Society>("Societies");
            Activities = database.GetCollection<Activity>("Activities");
            Members = database.GetCollection<Member>("Members");
            Keys = database.GetCollection<Key>("Keys");
            Rooms = database.GetCollection<Room>("Rooms");
            RoomProperties = database.GetCollection<RoomProperty>("RoomProperties");
            RoomBookings = database.GetCollection<RoomBooking>("RoomBookings");
        }

        public void Seed()
        {
            
        }

        #region Tables

        internal class Municipality
        {
            public Guid MunicipalityId { get; set; }
            public Guid SocietyId { get; set; }
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
            public int KeyId { get; set; }
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
            public int PropertyId { get; set; }
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
