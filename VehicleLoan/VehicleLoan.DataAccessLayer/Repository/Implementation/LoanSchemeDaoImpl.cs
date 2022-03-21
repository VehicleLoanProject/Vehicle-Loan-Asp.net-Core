using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;
using VehicleLoan.DataAccessLayer.Models;
using System.Linq;
using VehicleLoan.DataAccessLayer.Repository.Abstraction;

namespace VehicleLoan.DataAccessLayer.Repository.Implementation
{
   public class LoanSchemeDaoImpl : ILoanSchemeDao
    {
        public LoanSchemeDaoImpl()
        {

        }
        public bool AddLoanScheme(LoanSchemeModel businessLoanSchemeObj)
        {
            return true;
        }
<<<<<<< Updated upstream
        public List<LoanSchemeModel> FetchAllLoanSchemes()
        {
            List<LoanSchemeModel> businessLoanSchemes = null;
            try
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<LoanScheme> allLoanSchemes = db.LoanScheme;
                    if (allLoanSchemes.Count() > 0)
                    {
                        businessLoanSchemes =
                            allLoanSchemes
                             .Select(
                                (LoanScheme l) =>
                                     new LoanSchemeModel
                                     {
                                         SchemeId =l.SchemeId,
                                         SchemeName = l.SchemeName,
                                         MaxLoanAmount = l.MaxLoanAmount,
                                         InterestRate = l.InterestRate,
                                         Emi = l.Emi,
                                         ProcessingFee = l.ProcessingFee,
                                         AccountType = l.AccountType,
                                         CustomerId = l.CustomerId
                                     }
                                      )
                             .ToList<LoanSchemeModel>();

                    }
                }
                return businessLoanSchemes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteLoanScheme(int id)
        {
            try
            {
                using (var db = new VehicleloanContext())
                {
                    //LoanScheme loanScheme = db.LoanScheme.Where(x => x.SchemeId == schemeid
                    //LoanScheme loanscheme = db.Find(schemeid);
                    //db.LoanScheme.Remove(loanscheme);
                    //db.LoanScheme.Remove(db.LoanScheme.FirstOrDefault(e => e.CustomerId ==schemeid));
                    //LoanScheme loanScheme = (from c in db.LoanScheme where c.SchemeId==schemeid select c).FirstOrDefault();
                    //db.LoanScheme.Remove(loanScheme);
                    DbSet<LoanScheme> loanSchemeList = db.LoanScheme;
                    LoanScheme loanScheme = loanSchemeList.Where(l => l.SchemeId ==id).First();
                    loanSchemeList.Remove(loanScheme);
                    int rowAffected = db.SaveChanges();
                    return rowAffected;
                    //db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int UpdateLoanSchemeById(int schemeId, LoanSchemeModel loanSchemeModel)
        {
            //try
            //{

            using (var db = new VehicleloanContext())
            {
                /*LoanScheme l = db.LoanScheme.Find(loanSchemeModel.SchemeId);
                //LoanScheme l = new LoanScheme();
                l.SchemeId = loanSchemeModel.SchemeId;
                l.SchemeName = loanSchemeModel.SchemeName;
                l.MaxLoanAmount= loanSchemeModel.MaxLoanAmount;
                l.InterestRate= loanSchemeModel.InterestRate;
                l.Emi= loanSchemeModel.Emi;
                l.ProcessingFee=loanSchemeModel.ProcessingFee;
                l.AccountType= loanSchemeModel.AccountType;
                l.CustomerId= loanSchemeModel.CustomerId;
                db.SaveChanges();
                //db.Entry<LoanScheme>(l).State = System.Data.Entity.EntityState.Modified;*/
                var entity = db.LoanScheme.First(n => n.SchemeId == schemeId);
                if (entity!=null)
                {
                    // entity.SchemeId= loanSchemeModel.SchemeId;
                    entity.SchemeName=loanSchemeModel.SchemeName;
                    entity.MaxLoanAmount=loanSchemeModel.MaxLoanAmount;
                    entity.InterestRate=loanSchemeModel.InterestRate;
                    entity.Emi=loanSchemeModel.Emi;
                    entity.ProcessingFee=loanSchemeModel.ProcessingFee;
                    entity.AccountType= loanSchemeModel.AccountType;
                    entity.CustomerId=loanSchemeModel.CustomerId;
                    int result = db.SaveChanges();
                    return result;
                }
                else
                {
                    Exception ex = new Exception("No record to update");
                    throw ex;
                }


            }
            // }

        }
=======
            
>>>>>>> Stashed changes
    }
}
