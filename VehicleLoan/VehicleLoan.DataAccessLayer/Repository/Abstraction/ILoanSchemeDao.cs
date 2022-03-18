using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;

namespace VehicleLoan.DataAccessLayer.Repository.Abstraction
{
    interface ILoanSchemeDao
    {
        List<LoanSchemeModel> FetchAllLoanSchemes();

        int updateLoanScheme(LoanSchemeModel loanSchemeModel);

        int AddLoanScheme(LoanSchemeModel loanSchemeModel);
    }
}
