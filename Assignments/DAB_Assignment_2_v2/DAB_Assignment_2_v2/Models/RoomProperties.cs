using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Assignment_2_v2.Models
{
    class RoomProperties
    {
        public Guid PropertyId{ get; set; }

        public bool CoffeeMachine { get; set; }
        public bool Water { get; set; }
        public bool Toilet { get; set; }
        public bool Chairs { get; set; }
        public bool Wifi { get; set; }
        public bool SoccerGoals { get; set; }
        public bool SoundSystem { get; set; }
        public bool Tables { get; set; }
        public bool Whiteboard { get; set; }
    }
}
