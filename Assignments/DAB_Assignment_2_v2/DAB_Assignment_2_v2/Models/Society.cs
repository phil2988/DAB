using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Assignment_2_v2.Models
{
    public class Society
    {
        public Guid SocietyId { get; set; }
        public int Cvr { get; set; }
        public string Address {get;set;}
        
        public string ChairmanName{ get; set; }

        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; }
        
        public ICollection<SocietyMemberRelations> SocietyMemberRelations { get; set; }

    }
}
