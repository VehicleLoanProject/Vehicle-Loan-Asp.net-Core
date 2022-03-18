using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;
using VehicleLoan.DataAccessLayer.Repository.Abstraction;

namespace VehicleLoan.DataAccessLayer.Repository.Implementation
{
    class UserRegistrationDaoImpl : IUserRegistrationDao
    {
        public int AddRecord(UserRegistrationModel userModel)
        {
            return 0;
        }
        public int UpdateRecord(string password)
        {
            return 0;
        }
        public string SearchUserId(string userid) // for forgot password, search user id based on that, update password.
        {
            return "";
        }
        public int deleteRecord(int id)
        {
            return 0;
        }
        public List<UserRegistrationModel> GetUserRegistrationDetails()
        {
           
            return null;
        }


    }
}
