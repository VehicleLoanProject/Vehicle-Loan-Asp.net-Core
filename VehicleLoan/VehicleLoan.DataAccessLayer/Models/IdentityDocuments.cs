using System;
using System.Collections.Generic;

namespace VehicleLoan.DataAccessLayer.Models
{
    public partial class IdentityDocuments
    {
        public long IdentityId { get; set; }
        public string Imagepath { get; set; }
        public DateTime InsertedOn { get; set; }
        public int? CustomerId { get; set; }

        public virtual ApplicantDetails Customer { get; set; }
    }
}
