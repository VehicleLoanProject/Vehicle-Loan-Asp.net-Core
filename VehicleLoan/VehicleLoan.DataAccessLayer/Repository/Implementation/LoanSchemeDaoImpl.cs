using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;
using VehicleLoan.DataAccessLayer.Models;

namespace VehicleLoan.DataAccessLayer.Repository.Implementation
{
   public class LoanSchemeDaoImpl
    {
        public LoanSchemeDaoImpl()
        {

        }
        public bool AddLoanScheme(LoanSchemeModel businessLoanSchemeObj)
        {
            int result = 0;
            try
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<LoanScheme> allLoanSchemes = db.LoanScheme;
                    LoanScheme entityModelObject = new LoanScheme
                    {
                        SchemeId = businessLoanSchemeObj.SchemeId,
                        SchemeName = businessLoanSchemeObj.SchemeName,
                        MaxLoanAmount = businessLoanSchemeObj.MaxLoanAmount,
                        InterestRate = businessLoanSchemeObj.InterestRate,
                        Emi = businessLoanSchemeObj.Emi,
                        ProcessingFee = businessLoanSchemeObj.ProcessingFee,
                        AccountType = businessLoanSchemeObj.AccountType,
                        CustomerId = businessLoanSchemeObj.CustomerId,
                    };
                    allLoanSchemes.Add(entityModelObject);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
