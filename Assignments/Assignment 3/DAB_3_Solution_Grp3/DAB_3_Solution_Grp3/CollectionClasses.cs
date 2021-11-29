using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_3_Solution_Grp3
{

    class Municipality
    {
        [BsonId]
        public ObjectId MunicipalityId { get; set; }
        public List<Society> Societies { get; set; }
    }
    class Society
    {
        [BsonId]
        public ObjectId SocietyId { get; set; }
        public int Cvr { get; set; }
        public string Adress { get; set; }
        public string ChairmanName { get; set; }
        public Activity Activity { get; set; }
        public List<Member> Members { get; set; }
    }
    class Activity
    {
        [BsonId]
        public ObjectId ActivityId { get; set; }
        public string ActivityName { get; set; }
    }
    class Member
    {
        [BsonId]
        public ObjectId MemberId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Cpr { get; set; }
        public bool IsChairman { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }
        public List<Key> Keys { get; set; }
    }
    class Key
    {
        [BsonId]
        public ObjectId KeyId { get; set; }
        public int RoomNumber { get; set; }
        public string RoomAdress { get; set; }
    }
    class Room
    {
        [BsonId]
        public ObjectId RoomId { get; set; }
        public int RoomNumber { get; set; }
        public string RoomAdress { get; set; }
        public int MaxMembers { get; set; }
        public TimeSpan RoomAvailabilityStart { get; set; }
        public TimeSpan RoomAvailabilityEnd { get; set; }
        public List<RoomBooking> RoomBookings { get; set; }
    }
    class RoomProperty
    {
        [BsonId]
        public ObjectId PropertyId { get; set; }
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
    class RoomBooking
    {
        [BsonId]
        public ObjectId BookingId { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public Member BookedBy { get; set; }
    }

}
