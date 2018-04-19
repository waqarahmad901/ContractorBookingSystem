using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class CustomerSpaceUnitDto
    {
        public string SpaceUnitCombinedName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Amount { get; set; }
        public string NoOfInstallments { get; set; }
        public string Status { get; set; }
        
        public string CustomerId { get; set; }
    }
}
