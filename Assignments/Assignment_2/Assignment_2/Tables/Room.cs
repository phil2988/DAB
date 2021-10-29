using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment_2.Tables
{
    public partial class Room
    {
        public Room()
        {
            Members = new HashSet<Member>();
        }

        public int RoomId { get; set; }
        public int RoomKey { get; set; }
        public int? MaxMembers { get; set; }
        public TimeSpan? RoomAvailabilityStart { get; set; }
        public TimeSpan? RoomAvailabilityStop { get; set; }
        public string BookedByName { get; set; }
        public string BookedBySociety { get; set; }
        public TimeSpan? BookedStart { get; set; }
        public TimeSpan? BookedStop { get; set; }
        public string LocationAdress { get; set; }

        public virtual MunicipalityLocation LocationAdressNavigation { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
