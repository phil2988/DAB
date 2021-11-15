using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Assignment_2_v2.Models
{
    public class Room
    {
        // Compound key
        public int RoomKey { get; set; }
        public string RoomAdress { get; set; }

        public int MaxMembers { get; set; }
        public TimeSpan RoomAvailabilityStart { get; set; }
        public TimeSpan RoomAvailabilityEnd { get; set; }

        public Guid PropertyId { get; set; }
        public ICollection<RoomBooking> BookingIds { get; set; }
    }
}
