using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment_2.Tables
{
    public partial class Activity
    {
        public Activity()
        {
            Societies = new HashSet<Society>();
        }

        public string ActivityName { get; set; }

        public virtual ICollection<Society> Societies { get; set; }
    }
}
