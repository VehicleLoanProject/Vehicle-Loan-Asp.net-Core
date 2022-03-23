using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;

namespace VehicleLoan.DataAccessLayer.Repository.Abstraction
{
    public interface IJwtTokenManager
    {
        string GenerateJwt(UserRegistrationModel user);
    }
}
