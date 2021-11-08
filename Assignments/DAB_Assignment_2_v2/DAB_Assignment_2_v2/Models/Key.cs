using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Assignment_2_v2.Models
{
    public class Key
    {
        public Guid KeyId { get; set; }

        public int RoomKey { get; set; }
        public string RoomAdress { get; set; }

        public Room Room { get; set; }
        public Member Member { get; set; }
        public Guid MemberId { get; set; }
    }
}
