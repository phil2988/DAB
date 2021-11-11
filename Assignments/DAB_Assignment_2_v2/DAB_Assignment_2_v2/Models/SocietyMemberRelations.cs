using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Assignment_2_v2.Models
{
    public class SocietyMemberRelations
    {
        public Guid SocietyId { get; set; }
        public ICollection<Society> Society { get; set; }
        

        public Guid MemberId { get; set; }
        public ICollection<Member> Member { get; set; }
    }
}
