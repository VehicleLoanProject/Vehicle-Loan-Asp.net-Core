using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.DataAccessLayer.Models;

namespace VehicleLoanDataAccessLayer.Repository.Abstraction
{
    public interface ILoanDetailsDao
    {
        int AddLoanDetails(LoanDetails loanDetails);

        List<LoanDetailsModel> GetAllLoanDetails(); 
        
        public int DeleteLoanRecord(int id);
    }
}
 