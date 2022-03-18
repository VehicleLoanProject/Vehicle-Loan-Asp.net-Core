using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleLoan.BusinessModels
{
    public class ApplicationStatusModel
    {
        public ApplicationStatusModel()
        {
            LoanDetails = new HashSet<LoanDetailsModel>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<LoanDetailsModel> LoanDetails { get; set; }
    }
}
