using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;

namespace VehicleLoan.DataAccessLayer.Repository.Abstraction
{
    public interface ILoanSchemeDao
    {
        List<LoanSchemeModel> FetchAllLoanSchemes();

        int UpdateLoanSchemeById(int schemeid, LoanSchemeModel loanSchemeModel);

        bool AddLoanScheme(LoanSchemeModel loanSchemeModel);
        int DeleteLoanScheme(int id);
    }
}
