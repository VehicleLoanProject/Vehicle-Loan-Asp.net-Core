using System;
using System.Collections.Generic;

namespace VehicleLoanAPI.Models
{
    public partial class ApplicationStatus
    {
        public ApplicationStatus()
        {
            LoanDetails = new HashSet<LoanDetails>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<LoanDetails> LoanDetails { get; set; }
    }
}
