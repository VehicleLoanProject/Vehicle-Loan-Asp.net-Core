using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleLoan.BusinessModels
{
    public class IdentityDocumentsModel
    {
        public int IdentityId { get; set; }
        public byte[] Adharcard { get; set; }
        public byte[] Pancard { get; set; }
        public byte[] Photo { get; set; }
        public byte[] Salaryslip { get; set; }
        public int? CustomerId { get; set; }

        public virtual ApplicantDetailsModel Customer { get; set; }
    }
}
