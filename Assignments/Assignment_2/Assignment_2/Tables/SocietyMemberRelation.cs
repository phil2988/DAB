using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment_2.Tables
{
    public partial class SocietyMemberRelation
    {
        public long SocietyCvr { get; set; }
        public int MemberId { get; set; }

        public virtual Member Member { get; set; }
        public virtual Society SocietyCvrNavigation { get; set; }
    }
}
