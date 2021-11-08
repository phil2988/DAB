using System;

namespace DAB_Assignment_2_v2.Models
{
    public class Activity
    {
        public Guid ActivityId { get; set; }
        public string AcitivtyName { get; set; }
        public Guid SocietyId { get; set; }
        public Society Society { get; set; }
    }
}
