using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleLoan.BusinessModels
{
    public class RoleTypeModel
    {
        public RoleTypeModel()
        {
            UserRegistration = new HashSet<UserRegistrationModel>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserRegistrationModel> UserRegistration { get; set; }
    }
}
