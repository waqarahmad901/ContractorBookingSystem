using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvoiceEngine
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SpaceUnit
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public string Name { get; set; }
    }

    public class Agreement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NoofInstallments { get; set; }
    }

    public class Payment
    {
        public int Id { get; set; }
        public int AgreementId { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
    }

    public class FillUp
    {
        public static IEnumerable<Agreement> FillAgreements()
        {

            return new Agreement[]
            {
                new Agreement
                {
                    Id = 1,
                    Name = "Abc",
                    Amount = 12,
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Now,
                    NoofInstallments = 10
                },
                new Agreement
                {
                    Id = 2,
                    Name = "Abc2",
                    Amount = 12000,
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Now,
                    NoofInstallments = 10
                },
                new Agreement
                {
                    Id = 3,
                    Name = "Abc3",
                    Amount = 6544,
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Now,
                    NoofInstallments = 10
                },
            };
        }

        public static IEnumerable<Payment> FillPayments()
        {

            return new []
            {
                new Payment()
                {
                    Id = 1,
                    AgreementId = 2,
                    Amount = 12,
                    PaymentDate= DateTime.Today,
                    PaymentMethod= "Cash"
                },
                new Payment()
                {
                    Id = 1,
                    AgreementId = 2,
                    Amount = 14,
                    PaymentDate= DateTime.Today,
                    PaymentMethod= "Cheque"
                } 
            };
        }
    }
}