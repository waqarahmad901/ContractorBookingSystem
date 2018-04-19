using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataAccess
    {
        private ContratorBookingSystemEntities _context = new ContratorBookingSystemEntities();
        public bool AddBuilding(Building building)
        {
            _context.Buildings.Add(building);
            return _context.SaveChanges() > 0;
        }

        public IList<Customer> GetCustomers(string name="")
        {
            return _context.Customers.Where(x=> name == "" || x.Name.Contains(name)).ToList();
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _context.Customers.Where(x => x.Id == id).FirstOrDefault();
            return customer == null ? new Customer() : customer;
        }


        public IList<Building> GetBuildings()
        {
            return _context.Buildings.ToList();
        }

        public ContractPayment GetPaymentById(int payemtId)
        {
            return _context.ContractPayments.FirstOrDefault(x => x.Id == payemtId);
        }

        public List<Contract> GetContractByCustomerId(int customerId)
        {
            return (from c in _context.Contracts
                    join csu in _context.CustomerSpaceUnits on c.GroupId equals csu.GroupId
                    where csu.CustomerId == customerId
                    select c
                          ).Distinct().ToList();
        }

        public List<CustomerSpaceUnitDto> GetContractBySpaceUnitId(int SpaceUnitId)
        {
            return (from c in _context.Contracts
                    join csu in _context.CustomerSpaceUnits on c.GroupId equals csu.GroupId
                    where csu.SpaceUnitId == SpaceUnitId
                    select new CustomerSpaceUnitDto { CustomerId = csu.CustomerId + "-" + c.Id, SpaceUnitCombinedName = c.SpaceUnitCombinedName, StartDate = c.StartDate.Value, Status = c.Status, EndDate = c.EndDate.Value, NoOfInstallments = c.NoOfInstallments.ToString(), Amount = c.Amount.ToString() }
                          ).Distinct().ToList();
        }


        public List<ContractPayment> GetPaymentByContractId(int contractId)
        {
            return (from c in _context.ContractPayments
                    where c.ContractId == contractId
                    select c
                          ).Distinct().OrderBy(x => x.DueDate).OrderByDescending(x => x.Status).ToList();
        }


        public Contract GetContractById(int contractId)
        {

            return _context.Contracts.Include("ContractPayments").FirstOrDefault(x => x.Id == contractId);
        }

        public void UpdateContract(Contract contract)
        {
            _context.Contracts.Attach(contract);
            Update();
        }


        public Building GetBuildingById(int id)
        {
            return _context.Buildings.Where(x => x.Id == id).FirstOrDefault();
        }

        public void AddPaymentByContractId(int contractId, ContractPayment cp)
        {
            _context.Contracts.Where(x => x.Id == contractId).FirstOrDefault().ContractPayments.Add(cp);
            Update();
        }

        public bool AddSpaceUnit(SpaceUnit sp)
        {
            _context.SpaceUnits.Add(sp);
            return _context.SaveChanges() > 0;
        }
        public IList<SpaceUnit> GetSpaceUnitsByBuildingId(int Id)
        {
            return _context.SpaceUnits.Where(x => x.BuildingId == Id).ToList();
        }

        public SpaceUnit GetSpaceUnitsById(int Id)
        {
            return _context.SpaceUnits.Where(x => x.Id == Id).FirstOrDefault();
        }
        public bool Update()
        {
            return _context.SaveChanges() > 0;
        }

        public bool AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            return _context.SaveChanges() > 0;
        }

        public void AddContract(Contract contract)
        {
            _context.Contracts.Add(contract);
        }

        public void AddCustomerSpaceUnit(CustomerSpaceUnit cup)
        {
            _context.CustomerSpaceUnits.Add(cup);

        }

        public void DeleteCustomerSpaceUnitByGroupId(Guid groupId)
        {
            var list = _context.CustomerSpaceUnits.Where(x => x.GroupId == groupId).ToList();
            _context.CustomerSpaceUnits.RemoveRange(list);


        }

        public IList<CustomSpaceUnit> GetSpaceUnitWithBuildingsByBuildingId(int BuildingId)
        {
            return _context.SpaceUnits.Include("Building").Where(x => x.BuildingId == BuildingId).Select(x => new CustomSpaceUnit { Id = x.Id, Name = x.Name, GroupId = x.CustomerSpaceUnits.Count == 0 ? Guid.Empty : (Guid)x.CustomerSpaceUnits.FirstOrDefault().GroupId }).ToList();
        }

        public IList<CustomSpaceUnit> GetSpaceUnitWithBuildingsByGroupId(Guid groupId)
        {
            return _context.CustomerSpaceUnits.Where(x => x.GroupId == groupId).Select(x => new CustomSpaceUnit { Id = x.SpaceUnitId, Name = x.SpaceUnit.Name }).ToList();
        }

        public Building GetBuildingByGroupId(Guid groupId)
        {
            return _context.CustomerSpaceUnits.Where(x => x.GroupId == groupId).Select(x => x.SpaceUnit.Building).FirstOrDefault();
        }


        public List<MonthlyReportDto> GetMonthlyReport(DateTime? startDate, DateTime? endDate, string status)
        {
            var customerPaymentInformation = (from cont in _context.Contracts
                                              join csu in _context.CustomerSpaceUnits on cont.GroupId equals csu.GroupId
                                              join cus in _context.Customers on csu.CustomerId equals cus.Id
                                              join cp in _context.ContractPayments on cont.Id equals cp.ContractId
                                              where ((startDate == null || cp.DueDate >= startDate) && (endDate == null || cp.DueDate <= endDate)
                                              && (cp.Status == status) && (cp.Amount > 0)// && csu.SpaceUnit.Building.Name == "Hameed Building" && cont.SpaceUnitCombinedName == "Shop No 1"
                                              )
                                             
                                              select new MonthlyReportDto
                                              {
                                                  Agreement = null,
                                                  ContactNo = cus.ContactNumber.ToString(),
                                                  InstallmentAmount = cp.Amount,
                                                  Date = cp.DueDate.Value,
                                                  Status = cp.Status,
                                                  Type = cp.PaymentMethod,
                                                  Typeno = cont.SpaceUnitCombinedName,
                                                  Name = cus.Name,
                                                  BuildingName = csu.SpaceUnit.Building.Name,
                                                  Note = cp.Note,
                                                  GroupId = cont.GroupId.Value,
                                                  CpId = cp.Id

                                              }).OrderBy(x => x.Date).ToList();
            //customerPaymentInformation = customerPaymentInformation.GroupBy(x => new { x.Date,x.BuildingName,x.Typeno,x.Name }).Select(x => x.LastOrDefault()).ToList();

            if (status == PaymentStatus.COMPLETE)
            {
                return customerPaymentInformation;
            }

            var contractInfo = (from cont in _context.Contracts
                                join csu in _context.CustomerSpaceUnits on cont.GroupId equals csu.GroupId
                                join cus in _context.Customers on csu.CustomerId equals cus.Id
                                where ((startDate == null || cont.EndDate >= startDate) && (endDate == null || cont.EndDate <= endDate)
                                 && (cont.Amount > 0) // && csu.SpaceUnit.Building.Name == "Hameed Building" && cont.SpaceUnitCombinedName == "Shop No 1"
                                )
                                select new MonthlyReportDto
                                {
                                    Agreement = cont.Amount,
                                    ContactNo = cus.ContactNumber.ToString(),
                                    InstallmentAmount = null,
                                    Date = cont.EndDate.Value,
                                    Status = cont.Status,
                                    Type = "",
                                    Typeno = cont.SpaceUnitCombinedName,
                                    Name = cus.Name,
                                    BuildingName = csu.SpaceUnit.Building.Name,
                                    Note = "",
                                    GroupId = cont.GroupId.Value,
                                    CpId = cont.Id
                                }).OrderByDescending(x => x.Date).ToList();
     
           var tempContract = customerPaymentInformation.GroupBy(x => new { x.BuildingName, x.Typeno, x.Name }).Select(x =>
                               x.FirstOrDefault()).ToList();
 
            string[] buildingNames = tempContract.Select(x => x.BuildingName).ToArray();
            string[] Typeno = tempContract.Select(x => x.Typeno).ToArray();
            string[] Name = tempContract.Select(x => x.Name).ToArray();

            var bb = contractInfo.Where(x => !buildingNames.Equals(x.BuildingName) && !Typeno.Equals(x.Typeno) && !Name.Equals(x.Name))
                .GroupBy(x => new { x.BuildingName, x.Typeno, x.Name }).Select(x =>
                               x.FirstOrDefault()).ToList();

            return bb.Union(customerPaymentInformation).OrderBy(x => x.Date).ToList();

        }

        public void DeleteSpaceUnitById(int spId)
        {
            var su = GetSpaceUnitsById(spId);
            var csu = _context.CustomerSpaceUnits.Where(x => x.SpaceUnitId == spId);
            _context.CustomerSpaceUnits.RemoveRange(csu);
            _context.SpaceUnits.Remove(su);
            Update();
        }

        public void DeleteContractById(int ctId)
        {
            var cont = _context.Contracts.FirstOrDefault(x => x.Id == ctId);
            var cp = _context.ContractPayments.Where(x => x.ContractId == ctId);
            _context.ContractPayments.RemoveRange(cp);
            _context.Contracts.Remove(cont);
            Update();
        }

        public void DeletePaymentById(int paId)
        {
            var payment = _context.ContractPayments.FirstOrDefault(x => x.Id == paId);

            _context.ContractPayments.Remove(payment);
            Update();
        }

        public List<RentReportDto> GetRentReportData()
        {
            var rentDetail = (from b in _context.Buildings
                              select new RentReportDto
                              {
                                  BuildingName = b.Name,
                                  ArabicName = b.ArabicName,
                                  contractDto = (from su in _context.SpaceUnits
                                                 join csu in _context.CustomerSpaceUnits on su.Id equals csu.SpaceUnitId
                                                 join cus in _context.Customers on csu.CustomerId equals cus.Id
                                                 join cnt in _context.Contracts on csu.GroupId equals cnt.GroupId
                                                 where (su.BuildingId == b.Id)
                                                 select new ContractDto
                                                 {
                                                     ContractAmount = cnt.Amount.Value.ToString(),
                                                     ContractEndDate = cnt.EndDate.Value.ToString(),
                                                     ContractorName = cus.Name,
                                                     Contractpayments = cnt.ContractPayments.ToList(),
                                                     ContractStartDate = cnt.StartDate.Value.ToString(),
                                                     NoOfInstallments = cnt.NoOfInstallments.ToString(),
                                                     SpaceunitCombinedName = cnt.SpaceUnitCombinedName
                                                 }).GroupBy(g => new { g.SpaceunitCombinedName, g.ContractorName }).Select(g => g.FirstOrDefault()).ToList()
                              }).ToList();
            return rentDetail;
        }


    }
}
