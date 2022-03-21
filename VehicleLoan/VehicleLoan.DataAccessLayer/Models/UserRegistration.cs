using System;
using System.Collections.Generic;

namespace VehicleLoan.DataAccessLayer.Models
{
    public partial class UserRegistration
    {
        public UserRegistration()
        {
            ApplicantDetails = new HashSet<ApplicantDetails>();
        }

        public string UserId { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }

        public virtual RoleType Role { get; set; }
        public virtual ICollection<ApplicantDetails> ApplicantDetails { get; set; }
    }
}
