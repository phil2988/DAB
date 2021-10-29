using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment_2.Tables
{
    public partial class Chairman
    {
        public Chairman()
        {
            Societies = new HashSet<Society>();
        }

        public string ChairmanName { get; set; }
        public long? Cpr { get; set; }
        public string Adress { get; set; }
        public int? RoomKey { get; set; }
        public string LocationAdress { get; set; }

        public virtual ICollection<Society> Societies { get; set; }
    }
}
