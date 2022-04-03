using System;
using System.Collections.Generic;

namespace VehicleLoanAPI.Models
{
    public partial class RoleType
    {
        public RoleType()
        {
            UserRegistration = new HashSet<UserRegistration>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserRegistration> UserRegistration { get; set; }
    }
}
