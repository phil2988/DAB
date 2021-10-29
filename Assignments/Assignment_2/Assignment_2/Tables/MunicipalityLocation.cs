using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment_2.Tables
{
    public partial class MunicipalityLocation
    {
        public MunicipalityLocation()
        {
            Members = new HashSet<Member>();
            Rooms = new HashSet<Room>();
        }

        public string LocationAdress { get; set; }
        public int? MaxMembers { get; set; }
        public TimeSpan? LocationAvailabilityStart { get; set; }
        public TimeSpan? LocationAvailabilityStop { get; set; }
        public int? PropertyId { get; set; }

        public virtual LocationProperty Property { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
