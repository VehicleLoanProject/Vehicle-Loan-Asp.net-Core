using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;

namespace VehicleLoan.DataAccessLayer.Repository.Abstraction
{
    interface IVehicleDao
    {
        int AddVehicleDetails(VehicleModel vehicleModel);

        List<VehicleModel> FetchVehicleDetails(int id);


    }
}
