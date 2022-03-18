using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;

namespace VehicleLoan.DataAccessLayer.Repository.Abstraction
{
    interface IApplicantDetailsDao
    {
        List<ApplicantDetailsModel> FetchApplicantDetails();

        int AddApplicantDetails(ApplicantDetailsModel loanSchemeModel);
    }
}
