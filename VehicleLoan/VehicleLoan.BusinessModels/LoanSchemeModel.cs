using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleLoan.BusinessModels
{
    public class LoanSchemeModel
    {
        public int SchemeId { get; set; }
        public string SchemeName { get; set; }
        public decimal MaxLoanAmount { get; set; }
        public int InterestRate { get; set; }
        public decimal Emi { get; set; }
        public decimal ProcessingFee { get; set; }
        public string AccountType { get; set; }
        public int? CustomerId { get; set; }
        public string SchemeDescription { get; set; }


        public virtual ApplicantDetailsModel Customer { get; set; }
    }
}
