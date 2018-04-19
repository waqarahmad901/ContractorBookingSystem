using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class RentReportDto
    {
        public string BuildingName { get; set; }
        public string ArabicName { get; set; }
        public List<ContractDto> contractDto { get; set; }
        
    }
}
