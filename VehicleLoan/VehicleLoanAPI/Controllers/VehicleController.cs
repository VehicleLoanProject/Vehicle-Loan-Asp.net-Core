using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleLoan.BusinessModels;
using VehicleLoan.DataAccessLayer.Repository.Abstraction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleLoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IVehicleDao _vehicleDao = null;

        public VehicleController(IVehicleDao vehicleDao)
        {
            this._vehicleDao = vehicleDao;
        }
        // GET: api/<VehicleController>
        [HttpGet]
        public IActionResult GetAllVehicleDetails()
        {
            List<VehicleModel> allVehicles = null;
            try
            {
                allVehicles = _vehicleDao.GetAllVehicleDetails();

                return Ok(allVehicles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicleDetailsById(int id)
        {
            try
            {
                VehicleModel vehicle = _vehicleDao.GetVehicleDetailsById(id);

                return Ok(vehicle);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<VehicleController>
        [HttpPost]
        public IActionResult AddVehicleRecord([FromBody] VehicleModel vehicleObj)
        {
            try
            {
                var result = _vehicleDao.AddVehicleDetails(vehicleObj);
                return this.CreatedAtAction(
                    "AddVehicleRecord", new
                    {
                        Status = 201,
                        Response = result,
                        Data = vehicleObj
                    }
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.TargetSite);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecord(int id)
        {
            try
            {

                var result = _vehicleDao.DeleteVehicleRecord(id);

                return this.CreatedAtAction(
                    "DeleteRecord", new
                    {
                        Status = 201,
                        Response = result,
                        Data = id
                    }
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
