using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Assignment_2_v2.Models
{
    public class Member
    {
        public Guid MemberId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Cpr { get; set; }
        public bool IsChairman { get; set; }

    }
}
