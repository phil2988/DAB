using System;
using System.Collections.Generic;

namespace DAB_Assignment_2_v2.Models
{
    public class Member
    {
        public Guid MemberId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Cpr { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }
        public bool IsChairman { get; set; }

        public ICollection<SocietyMemberRelations> SocietyMemberRelations { get; set; }

        public Guid KeyId {get; set;}
        ICollection<Key> keys;
        public ICollection<Key> Keys 
        {
            get { return keys; }
            set { if (IsChairman) keys = value; } 
        }

        public bool ValidateChairmanStatus(Society s)
        {
            if( s.ChairmanName == "" &&
                Address != null && Address != "" && 
                PhoneNumber != null && PhoneNumber != "" && 
                PassportNumber != null && PassportNumber != "")
            {
                IsChairman = true;
                return true;
            }
            IsChairman = false;
            return false;
        }
    }
}
