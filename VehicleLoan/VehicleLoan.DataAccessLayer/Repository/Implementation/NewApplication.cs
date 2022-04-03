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
                    LoanDetailsDaoImpl loan = new LoanDetailsDaoImpl();
                    ApplicantDetailsDaoImpl applicant = new ApplicantDetailsDaoImpl();
                    VehicleDaoImpl vehicle = new VehicleDaoImpl();

                    

                    applicationList = (from l in loan.GetAllLoanDetailsOfNew()
                                       join a in applicant.FetchApplicantDetails() on l.CustomerId equals a.CustomerId
                                       join v in vehicle.GetAllVehicleDetails() on l.CustomerId equals v.CustomerId
                                       select new JoinTablesModel
                                       {
                                           CustomerId = l.CustomerId,
                                           AppliedOn = a.AppliedOn,
                                           FirstName = a.FirstName,
                                           MiddleName = a.MiddleName,
                                           LastName = a.LastName,
                                           Age = a.Age,
                                           Gender = a.Gender,
                                           ContactNo = a.ContactNo,
                                           EmailId = a.EmailId,
                                           Address = a.Address,
                                           State = a.State,
                                           City = a.City,
                                           Pincode = a.Pincode,
                                           TypeOfEmployement = a.TypeOfEmployement,
                                           YearlySalary = a.YearlySalary,
                                           ExistingEmi = a.ExistingEmi,

                                           LoanAmount = l.LoanAmount,
                                           LoanTenure = l.LoanTenure,
                                           InterestRate = l.InterestRate,

                                           CarMake = v.CarMake,
                                           CarModel = v.CarModel,
                                           ExshowroomPrice = v.ExshowroomPrice,
                                           OnroadPrice = v.OnroadPrice



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
