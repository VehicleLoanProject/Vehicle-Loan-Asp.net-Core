using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;

namespace VehicleLoan.DataAccessLayer.Repository.Abstraction
{
    public interface IUserRegistrationDao
    {
        public interface IUserRegistrationDao
        {
            int AddRecord(UserRegistrationModel userModel);
            int UpdateRecord(UserRegistrationModel userModel);
            int deleteRecord(string userid);
            string GetLoginDetails(string userid);


        }
    }
}
