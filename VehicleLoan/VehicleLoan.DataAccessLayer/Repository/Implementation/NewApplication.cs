using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleLoan.BusinessModels;
using VehicleLoan.DataAccessLayer.Models;

namespace VehicleLoan.DataAccessLayer.Repository.Implementation
{
    public class NewApplication
    {
        public List<JoinTablesModel> FetchNewApplication()
        {

            try
            {

                List<JoinTablesModel> applicationList = null;

                using (var db = new VehicleloanContext())
                {
                    //from loan details,status == approved.
                    DbSet<LoanDetails> allLoanDetails = db.LoanDetails;

                    IQueryable<LoanDetails> approvedRecords = allLoanDetails.Where(a => a.StatusId == 1);

                    DbSet<Vehicle> vehicleRecords = db.Vehicle;
                    //DbSet<IdentityDocuments> identityRecords = db.IdentityDocuments;
                    DbSet<ApplicantDetails> applicantEntity = db.ApplicantDetails;

                    /* IEnumerable<JoinTablesModel> querTwo = (from loanItem in approvedRecords
                                                              join applicant in applicantEntity on loanItem.CustomerId equals applicant.CustomerId
                                                              join vehicle in vehicleRecords on loanItem.CustomerId equals vehicle.CustomerId
                                                            //join identityDocument in identityRecords on loanItem.CustomerId equals identityDocument.CustomerId

                    */



                    applicationList = (from loanItem in approvedRecords
                                       join applicant in applicantEntity on loanItem.CustomerId equals applicant.CustomerId
                                       join vehicle in vehicleRecords on applicant.CustomerId equals vehicle.CustomerId
                                       //join identityDocument in identityRecords on loanItem.CustomerId equals identityDocument.CustomerId
                                       select new JoinTablesModel
                                       {
                                           CustomerId = loanItem.CustomerId,
                                           AppliedOn = applicant.AppliedOn,
                                           FirstName = applicant.FirstName,
                                           MiddleName = applicant.MiddleName,
                                           LastName = applicant.LastName,
                                           Age = applicant.Age,
                                           Gender = applicant.Gender,
                                           ContactNo = applicant.ContactNo,
                                           EmailId = applicant.EmailId,
                                           Address = applicant.Address,
                                           State = applicant.State,
                                           City = applicant.City,
                                           Pincode = applicant.Pincode,
                                           TypeOfEmployement = applicant.TypeOfEmployement,
                                           YearlySalary = applicant.YearlySalary,
                                           ExistingEmi = applicant.ExistingEmi,

                                           LoanAmount = loanItem.LoanAmount,
                                           LoanTenure = loanItem.LoanTenure,
                                           InterestRate = loanItem.InterestRate,

                                           CarMake = vehicle.CarMake,
                                           CarModel = vehicle.CarModel,
                                           ExshowroomPrice = vehicle.ExshowroomPrice,
                                           OnroadPrice = vehicle.OnroadPrice
                                       }).ToList<JoinTablesModel>();



                }
                return applicationList;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
