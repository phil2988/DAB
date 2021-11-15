
using System;
using System.Collections.Generic;

namespace DAB_Assignment_2_v2.Models
{
    public class SocietyMemberRelations
    {
        public Guid MemberId { get; set; }
        public Member Member { get; set; }
        
        public Guid SocietyId { get; set; }
        public Society Society { get; set; }
        
    }
}
