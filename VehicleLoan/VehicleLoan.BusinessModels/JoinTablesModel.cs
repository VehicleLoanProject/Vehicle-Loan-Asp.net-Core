using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleLoan.BusinessModels
{
    public class JoinTablesModel
    {
        public int CustomerId { get; set; }
        public DateTime AppliedOn { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public long ContactNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public string TypeOfEmployement { get; set; }
        public decimal YearlySalary { get; set; }
        public decimal? ExistingEmi { get; set; }

        public decimal LoanAmount { get; set; }
        public int LoanTenure { get; set; }
        public int InterestRate { get; set; }

        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public decimal? ExshowroomPrice { get; set; }
        public decimal? OnroadPrice { get; set; }
    }
}
