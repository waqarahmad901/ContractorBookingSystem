using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class ContractDto
    {
        public string SpaceunitCombinedName { get; set; }
        public string ContractorName { get; set; }
        public string ContractStartDate { get; set; }
        public string ContractEndDate { get; set; }
        public string ContractAmount { get; set; }
        public string NoOfInstallments { get; set; }

        public List<ContractPayment> Contractpayments { get; set; }

    }
}
