using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment_2.Tables
{
    public partial class LocationProperty
    {
        public LocationProperty()
        {
            MunicipalityLocations = new HashSet<MunicipalityLocation>();
        }

        public int PropertyId { get; set; }
        public bool? CoffeeMachine { get; set; }
        public bool? Toilet { get; set; }
        public bool? Water { get; set; }
        public bool? Chairs { get; set; }
        public bool? Wifi { get; set; }
        public bool? Whiteboard { get; set; }
        public bool? SoccerGoals { get; set; }
        public bool? Tables { get; set; }
        public bool? SoundSystem { get; set; }

        public virtual ICollection<MunicipalityLocation> MunicipalityLocations { get; set; }
    }
}
