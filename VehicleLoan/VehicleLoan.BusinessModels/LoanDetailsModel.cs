using System;
using System.Collections.Generic;
using VehicleLoan.BusinessModels;

namespace VehicleLoan.DataAccessLayer.Models
{
    public partial class LoanDetailsModel
    {
        public int LoanAppId { get; set; }
        public decimal LoanAmount { get; set; }
        public int LoanTenure { get; set; }
        public int InterestRate { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }

        public virtual ApplicantDetailsModel Customer { get; set; }
        public virtual ApplicationStatusModel Status { get; set; }
    }
}
