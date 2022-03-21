using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;

namespace VehicleLoan.DataAccessLayer.Repository.Abstraction
{
    public interface IApplicantDetailsDao
    {
        List<ApplicantDetailsModel> FetchApplicantDetails();

        bool AddApplicantDetails(ApplicantDetailsModel loanSchemeModel);
        int DeleteApplicantDetails(int customerid);
    }
}
