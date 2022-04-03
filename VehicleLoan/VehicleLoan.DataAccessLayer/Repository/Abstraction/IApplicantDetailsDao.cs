using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;

namespace VehicleLoan.DataAccessLayer.Repository.Abstraction
{
    public interface IApplicantDetailsDao
    {
        List<ApplicantDetailsModel> FetchApplicantDetails();
        List<ApplicantDetailsModel> FetchRejectedDetails();
        List<ApplicantDetailsModel> FetchClientDetails();
        int AddApplicantDetails(ApplicantDetailsModel applicantDetailsModel);
        int DeleteApplicantDetails(int customerid);
    }
}
