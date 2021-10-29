using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment_2.Tables
{
    public partial class Society
    {
        public long SocietyCvr { get; set; }
        public string SocietyName { get; set; }
        public string SocietyAdress { get; set; }
        public string ActivityName { get; set; }
        public string ChairmanName { get; set; }

        public virtual Activity ActivityNameNavigation { get; set; }
        public virtual Chairman ChairmanNameNavigation { get; set; }
    }
}
