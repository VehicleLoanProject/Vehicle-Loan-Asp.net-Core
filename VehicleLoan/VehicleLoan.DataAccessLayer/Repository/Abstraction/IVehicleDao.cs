using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.BusinessModels;

namespace VehicleLoan.DataAccessLayer.Repository.Abstraction
{
    public interface IVehicleDao
    {
        int AddVehicleDetails(VehicleModel vehicleModel);

        List<VehicleModel> GetAllVehicleDetails();
        VehicleModel GetVehicleDetailsById(int id);
        public int DeleteVehicleRecord(int id);

    }
}
