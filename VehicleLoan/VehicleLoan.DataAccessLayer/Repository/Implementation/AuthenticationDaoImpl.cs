using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleLoan.BusinessModels;
using VehicleLoan.DataAccessLayer.Models;
using VehicleLoan.DataAccessLayer.Repository.Abstraction;

namespace VehicleLoan.DataAccessLayer.Repository.Implementation
{
    public class AuthenticationDaoImpl: IAuthentication
    {
        public bool AuthenticateUser(UserRegistrationModel userInfo)
        {
            try
            {
                bool status;
                using (var db = new VehicleloanContext())
                {
                    var allUsers = db.UserRegistration;
                    status = allUsers.Any(user => user.UserId == userInfo.UserId && user.Password == userInfo.Password && user.RoleId == userInfo.RoleId);
                }
                return status;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
              
            
        }
    }
}
