using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleLoan.BusinessModels;
using VehicleLoan.DataAccessLayer.Models;
using VehicleLoan.DataAccessLayer.Repository.Abstraction;

namespace VehicleLoan.DataAccessLayer.Repository.Implementation
{
    public class UserRegistrationDaoImpl : IUserRegistrationDao
    {
        public int AddRecord(UserRegistrationModel userModel)
        {
            try
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<UserRegistration> allUsers = db.UserRegistration;
                    UserRegistration user = new UserRegistration()
                    {
                        UserId = userModel.UserId,
                        Password = userModel.Password,
                        RoleId = userModel.RoleId
                    };

                    allUsers.Add(user);
                    int rowAffected = db.SaveChanges();
                    return rowAffected;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int UpdateRecord(UserRegistrationModel userModel)
        {
            try
            {
                using (var db = new VehicleloanContext())
                {
                    UserRegistration user = db.UserRegistration.Find(userModel.UserId);

                    UserRegistration record = null;
                    record.Password = userModel.Password;
   
                    int rawaffected = db.SaveChanges();
                    return rawaffected;
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int DeleteRecord(string id)
        {
            try
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<UserRegistration> userRecord = db.UserRegistration;

                    UserRegistration record = userRecord.Where(p => p.UserId == id).First();
                    userRecord.Remove(record);
                    int rawAffected = db.SaveChanges();
                    return rawAffected;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetLoginDetails(string userid)
        {
            try
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<UserRegistration> userRecords = db.UserRegistration;

                    IQueryable<string> query = from i in userRecords
                                               where i.UserId == userid
                                               select i.Password;
                    string password = " ";

                    if (query != null && query.Count() > 0)
                    {
                        password = query.First();
                        return password;
                    }
                    else
                    {
                        Exception ex = new Exception("User id is not found");
                        throw ex;
                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
