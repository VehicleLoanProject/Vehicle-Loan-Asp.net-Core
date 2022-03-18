using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleLoan.BusinessModels
{
    public class UserRegistrationModel
    {
        public UserRegistrationModel()
        {
            ApplicantDetails = new HashSet<ApplicantDetailsModel>();
        }

        public string UserId { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual RoleTypeModel Role { get; set; }
        public virtual ICollection<ApplicantDetailsModel> ApplicantDetails { get; set; }
    }
}
