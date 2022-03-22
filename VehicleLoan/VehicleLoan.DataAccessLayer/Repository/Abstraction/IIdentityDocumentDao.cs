using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;

namespace VehicleLoan.DataAccessLayer.Repository.Abstraction
{
    public interface IIdentityDocumentDao
    {
        int AddIdentityDocument(IdentityDocumentsModel identityDocumentsModel);

        List<IdentityDocumentsModel> GetAllIdentityDocuement();
        int DeleteIdentityDocuements(int id);
    }
}
