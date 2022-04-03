using System;
using System.Collections.Generic;

namespace VehicleLoan.DataAccessLayer.Models
{
    public partial class LoanDetails
    {
        public int LoanAppId { get; set; }
        public decimal LoanAmount { get; set; }
        public int LoanTenure { get; set; }
        public int InterestRate { get; set; }
        public int? CustomerId { get; set; }
        public int? StatusId { get; set; }
        public string LoanSchemeName { get; set; }

        public virtual ApplicantDetails Customer { get; set; }
        public virtual ApplicationStatus Status { get; set; }
    }
}
