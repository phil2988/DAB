using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment_2.Tables
{
    public partial class Member
    {
        public int MemberId { get; set; }
        public int? RoomId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public long? Cpr { get; set; }
        public string LocationAdress { get; set; }

        public virtual MunicipalityLocation LocationAdressNavigation { get; set; }
        public virtual Room Room { get; set; }
    }
}
