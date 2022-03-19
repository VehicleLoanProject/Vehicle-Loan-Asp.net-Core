using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleLoan.BusinessModels;
using VehicleLoan.DataAccessLayer.Models;
using VehicleLoan.DataAccessLayer.Repository.Abstraction;

namespace VehicleLoan.DataAccessLayer.Repository.Implementation
{
    public class VehicleDaoImpl : IVehicleDao
    {
        public int AddVehicleDetails(VehicleModel vehicleModel)
        {
            Vehicle vehicleObj = null;
            try
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<Vehicle> vehicleList = db.Vehicle;

                    vehicleObj = new Vehicle()
                    {
                        CarModel = vehicleModel.CarModel,
                        CarMake = vehicleModel.CarMake,
                        ExshowroomPrice = vehicleModel.ExshowroomPrice,
                        OnroadPrice = vehicleModel.OnroadPrice,
                        CustomerId = vehicleModel.CustomerId
                    };
                    vehicleList.Add(vehicleObj);
                    int rawAffected = db.SaveChanges();
                    return rawAffected;

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int DeleteVehicleRecord(int id)
        {
            try
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<Vehicle> vehicleList = db.Vehicle;

                    Vehicle vehicle = vehicleList.Where(p => p.VehicleId == id).First();
                    vehicleList.Remove(vehicle);
                    int rawAffected = db.SaveChanges();
                    return rawAffected;

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<VehicleModel> GetAllVehicleDetails()
        {
            List<VehicleModel> vehicleList = null;
            try
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<Vehicle> allVehicles = db.Vehicle;
                    vehicleList = allVehicles.Select(
                        set => new VehicleModel
                        {
                            CustomerId = set.CustomerId,
                            CarMake = set.CarMake,
                            CarModel = set.CarModel,
                            ExshowroomPrice = set.ExshowroomPrice,
                            OnroadPrice = set.OnroadPrice

                        }
                    ).ToList<VehicleModel>();
                    db.SaveChanges();
                    return vehicleList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public VehicleModel GetVehicleDetailsById(int id)
        {
            try
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<Vehicle> allVehicles = db.Vehicle;
                    Vehicle vehicle = allVehicles.Where(p => p.CustomerId == id).First();

                    VehicleModel vehicleModel = new VehicleModel()
                    {
                        CustomerId = vehicle.CustomerId,
                        CarMake = vehicle.CarMake,
                        CarModel = vehicle.CarModel,
                        ExshowroomPrice = vehicle.ExshowroomPrice,
                        OnroadPrice = vehicle.OnroadPrice

                    };
                    return vehicleModel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
