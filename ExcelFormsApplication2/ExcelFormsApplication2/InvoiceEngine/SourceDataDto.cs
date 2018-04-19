using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvoiceEngine
{
    public class SourceDataDto
    {
        public string Company { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCodeCity { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string InternationalAppNo { get; set; }
        public string IpcText { get; set; }
        public string PubNo { get; set; }
        public string InvoiceNo { get; set; }
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime PaymentDueDate { get; set; }

        public DateTime PublicationDate { get; set; }
        public string InventorName { get; set; }
        public DateTime InternationalFilingDate { get; set; }
 
    }
}
