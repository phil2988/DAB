using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Tables
{
    public class RoomBooking
    {   
        public int RoomBookingId { get; set; }
        public Member BookedByMember { get; set; }
        public Society BookedBySociety { get; set; }
        public string LocationAdress { get; set; }
        
        public int RoomForeignKey { get; set; } 
        [ForeignKey("RoomForeginKey")]
        public ICollection<Room> Room { get; set; }

    }
}
