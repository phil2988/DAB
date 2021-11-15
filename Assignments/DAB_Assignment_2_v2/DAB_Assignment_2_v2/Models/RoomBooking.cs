using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Assignment_2_v2.Models
{
    public class RoomBooking
    {
        public Guid BookingId { get; set; }

        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public Member BookedBy { get; set; }

        public Room Room { get; set; }
    }
}
