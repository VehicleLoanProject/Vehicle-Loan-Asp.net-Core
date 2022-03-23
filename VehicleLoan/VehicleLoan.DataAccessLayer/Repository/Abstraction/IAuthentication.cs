using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;
using VehicleLoan.DataAccessLayer.Models;

namespace VehicleLoan.DataAccessLayer.Repository.Abstraction
{
    interface IAuthentication
    {
        bool AuthenticateUser(UserRegistrationModel userInfo);
    }
}
