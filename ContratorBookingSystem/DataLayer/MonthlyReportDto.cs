using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MonthlyReportDto
    {
        public String Typeno { get; set; }
        public DateTime Date { get; set; }
        public decimal? Agreement { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public string ContactNo { get; set; }
        public String Type { get; set; }
        public String Status { get; set; }
        public String Name { get; set; }
        public int CpId { get; set; }

        public String BuildingName { get; set; }
        public String Note { get; set; }
        public Guid GroupId{ get; set; }

    }
}
