using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;

namespace VehicleLoan.DataAccessLayer.Repository.Abstraction
{
    public interface IRoleTypeDao
    {
        //after login fetch the role type based on user id.
        string FetchRoleNameByUserId(string id);
    }
}
