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

        public Guid AcivityId { get; set; }
        public Activity Activity { get; set; }

        public Guid MuniciplaityId { get; set; }
        public Municipality Municipality { get; set; }
    
        public ICollection<Member> Members { get; set; }
    }
}
