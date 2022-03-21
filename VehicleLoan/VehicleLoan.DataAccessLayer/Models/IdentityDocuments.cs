using System;
using System.Collections.Generic;

namespace VehicleLoan.DataAccessLayer.Models
{
    public partial class IdentityDocuments
    {
        public int IdentityId { get; set; }
        public byte[] Adharcard { get; set; }
        public byte[] Pancard { get; set; }
        public byte[] Photo { get; set; }
        public byte[] Salaryslip { get; set; }
        public int? CustomerId { get; set; }

        public virtual ApplicantDetails Customer { get; set; }
    }
}
