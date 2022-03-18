using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;

namespace VehicleLoan.DataAccessLayer.Repository.Abstraction
{
    interface IUserRegistrationDao
    {
        interface IUserRegistrationDao
        {
            int AddRecord(UserRegistrationModel userModel);
            int UpdateRecord(string password);
            string SearchUserId(string userid); // for forgot password, search user id based on that, update password.
            int deleteRecord(int id);
            List<UserRegistrationModel> GetUserRegistrationDetails();


        }
    }
}
