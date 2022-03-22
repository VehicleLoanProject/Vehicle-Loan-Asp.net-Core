using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleLoan.DataAccessLayer.Models;
using VehicleLoanDataAccessLayer.Repository.Abstraction;

namespace VehicleLoanDataAccessLayer.Repository.Implimantation
{
    public class LoanDetailsDaoImpl : ILoanDetailsDao
    {
        public int AddLoanDetails(LoanDetails loanDetails)
        {
            LoanDetails loanDetailsobj = null;
            try
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<LoanDetails> loanDetailsList = db.LoanDetails;
                    loanDetailsobj = new LoanDetails()
                    {
                        LoanAppId = loanDetails.LoanAppId,
                        LoanAmount = loanDetails.LoanAmount,
                        LoanTenure = loanDetails.LoanTenure,
                        InterestRate = loanDetails.InterestRate


                    };
                    loanDetailsobj.Add(loanDetailsobj);
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

        public int DeleteLoanRecord(int id)
        {
            try
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<LoanDetails> loanDetailsList = db.LoanDetails;

                    LoanDetails loanDetails = loanDetailsList.Where(p => p.LoanAppId == id).First();
                    loanDetailsList.Remove(loanDetails);
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

        public List<LoanDetailsModel> GetAllLoanDetails()
        {

            List<LoanDetailsModel> loanDetailsList = null;
            try
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<LoanDetails> allLoanDetails = db.LoanDetails;
                    loanDetailsList = allLoanDetails.Select(
                        set => new LoanDetailsModel
                        {
                            LoanAppId = set.LoanAppId,
                            LoanAmount = set.LoanAmount,
                            LoanTenure = set.LoanTenure,
                            InterestRate = set.InterestRate

                        }
                    ).ToList<LoanDetailsModel>();
                    db.SaveChanges();
                    return loanDetailsList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
