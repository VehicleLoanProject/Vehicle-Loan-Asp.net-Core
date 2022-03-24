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
    public class ApplicantDetailsDaoImpl : IApplicantDetailsDao
    {
        public bool AddApplicantDetails(ApplicantDetailsModel applicantDetailsModel)
        {
            try
            {
                int result = 0;
                using (var db = new VehicleloanContext())
                {
                    DbSet<ApplicantDetails> newApplicantDetails = db.ApplicantDetails;
                    ApplicantDetails applicantDetails = new ApplicantDetails()
                    {
                        AppliedOn = applicantDetailsModel.AppliedOn,
                        FirstName = applicantDetailsModel.FirstName,
                        MiddleName = applicantDetailsModel.MiddleName,
                        LastName = applicantDetailsModel.LastName,
                        Age = applicantDetailsModel.Age,
                        Gender = applicantDetailsModel.Gender,
                        ContactNo = applicantDetailsModel.ContactNo,
                        EmailId = applicantDetailsModel.EmailId,
                        Address = applicantDetailsModel.Address,
                        State = applicantDetailsModel.State,
                        City = applicantDetailsModel.City,
                        Pincode = applicantDetailsModel.Pincode,
                        TypeOfEmployement = applicantDetailsModel.TypeOfEmployement,
                        YearlySalary = applicantDetailsModel.YearlySalary,
                        ExistingEmi = applicantDetailsModel.ExistingEmi,
                        UserId = applicantDetailsModel.UserId

                    };
                    newApplicantDetails.Add(applicantDetails);
                    result = db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ApplicantDetailsModel> FetchClientDetails()
        {
            List<ApplicantDetailsModel> applicantDetails = new List<ApplicantDetailsModel>();
            try
            {

                using (var db = new VehicleloanContext())
                {
                    //from loan details,status == approved.
                    DbSet<LoanDetails> allLoanDetails = db.LoanDetails;

                    IQueryable<LoanDetails> approvedRecords = allLoanDetails.Where(a => a.StatusId == 2);

                    DbSet<ApplicantDetails> applicantEntity = db.ApplicantDetails;

                    IEnumerable<ApplicantDetails> query = from i in approvedRecords
                                                          join j in applicantEntity
                                                          on i.CustomerId equals j.CustomerId
                                                          select j;
                    IEnumerable<ApplicantDetailsModel> querTwo = query.Select(applicantDetail =>
                    new ApplicantDetailsModel
                    {

                        CustomerId = applicantDetail.CustomerId,
                        AppliedOn = applicantDetail.AppliedOn,
                        FirstName = applicantDetail.FirstName,
                        MiddleName = applicantDetail.MiddleName,
                        LastName = applicantDetail.LastName,
                        Age = applicantDetail.Age,
                        Gender = applicantDetail.Gender,
                        ContactNo = applicantDetail.ContactNo,
                        EmailId = applicantDetail.EmailId,
                        Address = applicantDetail.Address,
                        State = applicantDetail.State,
                        City = applicantDetail.City,
                        Pincode = applicantDetail.Pincode,
                        TypeOfEmployement = applicantDetail.TypeOfEmployement,
                        YearlySalary = applicantDetail.YearlySalary,
                        ExistingEmi = applicantDetail.ExistingEmi,
                        UserId = applicantDetail.UserId
                    });
                    foreach (ApplicantDetailsModel item in querTwo)
                    {
                        applicantDetails.Add(item);
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return applicantDetails;
        }
        public List<ApplicantDetailsModel> FetchRejectedDetails()
        {
            List<ApplicantDetailsModel> applicantDetails = new List<ApplicantDetailsModel>();
            try
            {


                using (var db = new VehicleloanContext())
                {
                    //from loan details,status == approved.
                    DbSet<LoanDetails> allLoanDetails = db.LoanDetails;

                    IQueryable<LoanDetails> approvedRecords = allLoanDetails.Where(a => a.StatusId == 3);

                    DbSet<ApplicantDetails> applicantEntity = db.ApplicantDetails;

                    IEnumerable<ApplicantDetails> query = from i in approvedRecords
                                                          join j in applicantEntity
                                                          on i.CustomerId equals j.CustomerId
                                                          select j;
                    IEnumerable<ApplicantDetailsModel> querTwo = query.Select(applicantDetail =>
                     new ApplicantDetailsModel
                     {

                         CustomerId = applicantDetail.CustomerId,
                         AppliedOn = applicantDetail.AppliedOn,
                         FirstName = applicantDetail.FirstName,
                         MiddleName = applicantDetail.MiddleName,
                         LastName = applicantDetail.LastName,
                         Age = applicantDetail.Age,
                         Gender = applicantDetail.Gender,
                         ContactNo = applicantDetail.ContactNo,
                         EmailId = applicantDetail.EmailId,
                         Address = applicantDetail.Address,
                         State = applicantDetail.State,
                         City = applicantDetail.City,
                         Pincode = applicantDetail.Pincode,
                         TypeOfEmployement = applicantDetail.TypeOfEmployement,
                         YearlySalary = applicantDetail.YearlySalary,
                         ExistingEmi = applicantDetail.ExistingEmi,
                         UserId = applicantDetail.UserId
                     });
                    foreach (ApplicantDetailsModel item in querTwo)
                    {
                        applicantDetails.Add(item);
                    }


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return applicantDetails;
        }


        public List<ApplicantDetailsModel> FetchApplicantDetails()
        {
            List<ApplicantDetailsModel> applicantDetails = null;
            try
            {
                using (var db=new VehicleloanContext())
                {
                    DbSet<ApplicantDetails> applicantEntity = db.ApplicantDetails;
                    applicantDetails= applicantEntity.Select(applicantDetail =>
                    new ApplicantDetailsModel
                    {

                        CustomerId = applicantDetail.CustomerId,
                        AppliedOn = applicantDetail.AppliedOn,
                        FirstName = applicantDetail.FirstName,
                        MiddleName = applicantDetail.MiddleName,
                        LastName = applicantDetail.LastName,
                        Age = applicantDetail.Age,
                        Gender = applicantDetail.Gender,
                        ContactNo = applicantDetail.ContactNo,
                        EmailId = applicantDetail.EmailId,
                        Address = applicantDetail.Address,
                        State = applicantDetail.State,
                        City = applicantDetail.City,
                        Pincode = applicantDetail.Pincode,
                        TypeOfEmployement = applicantDetail.TypeOfEmployement,
                        YearlySalary = applicantDetail.YearlySalary,
                        ExistingEmi = applicantDetail.ExistingEmi,
                        UserId = applicantDetail.UserId
                    }).ToList<ApplicantDetailsModel>();

                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return applicantDetails;
        }

        public int DeleteApplicantDetails(int customerid)
        {

            try
            {
                using (var db = new VehicleloanContext())
                {

                    DbSet<ApplicantDetails> allApplicants = db.ApplicantDetails;
                    ApplicantDetails loanScheme = allApplicants.Where(l => l.CustomerId == customerid).First();
                    allApplicants.Remove(loanScheme);
                    int rowAffected = db.SaveChanges();
                    return rowAffected;
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
