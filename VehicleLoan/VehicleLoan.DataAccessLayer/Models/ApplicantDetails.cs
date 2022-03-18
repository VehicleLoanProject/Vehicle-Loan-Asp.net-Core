using System;
using System.Collections.Generic;

namespace VehicleLoan.DataAccessLayer.Models
{
    public partial class ApplicantDetails
    {
        public ApplicantDetails()
        {
            IdentityDocuments = new HashSet<IdentityDocuments>();
            LoanDetails = new HashSet<LoanDetails>();
            LoanScheme = new HashSet<LoanScheme>();
            Vehicle = new HashSet<Vehicle>();
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

        public virtual UserRegistration User { get; set; }
        public virtual ICollection<IdentityDocuments> IdentityDocuments { get; set; }
        public virtual ICollection<LoanDetails> LoanDetails { get; set; }
        public virtual ICollection<LoanScheme> LoanScheme { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
