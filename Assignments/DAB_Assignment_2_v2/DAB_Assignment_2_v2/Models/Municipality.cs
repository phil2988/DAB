using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Assignment_2_v2.Models
{
    public class Municipality
    {
        public Guid MunicipalityId { get; set; }

        public Guid SocietyId { get; set; }
        public ICollection<Society> Societies { get; set; }
    }
}
