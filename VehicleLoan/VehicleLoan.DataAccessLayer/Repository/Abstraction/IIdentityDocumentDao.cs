using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;

namespace VehicleLoan.DataAccessLayer.Repository.Abstraction
{
    interface IIdentityDocumentDao
    {
        int AddIdentityDocument(IdentityDocumentsModel identityDocumentsModel);

        List<IdentityDocumentsModel> FetchVehicleDetails(int id);
    }
}
