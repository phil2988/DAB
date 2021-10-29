using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment_2.Tables
{
    public partial class Municipality
    {
        public long SocietyCvr { get; set; }

        public virtual Society SocietyCvrNavigation { get; set; }
    }
}
