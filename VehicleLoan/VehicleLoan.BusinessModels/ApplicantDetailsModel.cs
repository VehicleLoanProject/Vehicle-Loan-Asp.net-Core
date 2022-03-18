using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleLoan.BusinessModels
{
   public class ApplicantDetailsModel
    {
        public ApplicantDetailsModel()
        {
            IdentityDocuments = new HashSet<IdentityDocumentsModel>();
            LoanDetails = new HashSet<LoanDetailsModel>();
            LoanScheme = new HashSet<LoanSchemeModel>();
            Vehicle = new HashSet<VehicleModel>();
        }

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
        public string UserId { get; set; }

        public virtual UserRegistrationModel User { get; set; }
        public virtual ICollection<IdentityDocumentsModel> IdentityDocuments { get; set; }
        public virtual ICollection<LoanDetailsModel> LoanDetails { get; set; }
        public virtual ICollection<LoanSchemeModel> LoanScheme { get; set; }
        public virtual ICollection<VehicleModel> Vehicle { get; set; }
    }
}
