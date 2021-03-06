using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleLoan.BusinessModels;
using VehicleLoan.DataAccessLayer.Repository.Abstraction;
using VehicleLoan.DataAccessLayer.Repository.Implementation;



namespace VehicleLoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private IApplicantDetailsDao _applicantDetailsDao;

        public ApplicantController(IApplicantDetailsDao applicantDetailsDao)
        {
            _applicantDetailsDao = applicantDetailsDao;
        }

        [HttpPost]
        [Route("AddApplicant")]
        public IActionResult AddApplicantDetails(ApplicantDetailsModel applicantDetailsModel)
        {
            try
            {

                int customerId = _applicantDetailsDao.AddApplicantDetails(applicantDetailsModel);
                return this.CreatedAtAction(
                "AddApplicantDetails", new
                {
                    Status = 201,
                    Response = true,
                    Data = customerId
                }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{customerid}")]
        public IActionResult Delete(int customerid)
        {
            try
            {

                var result = _applicantDetailsDao.DeleteApplicantDetails(customerid);
                return this.CreatedAtAction(
                    "Delete",
                    new
                    {
                        StatusCode = 201,
                        Response = result,
                        Data = customerid
                    }
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("applicantDetails")]
        public IActionResult ApplicantDetails()
        {
            try
            {
                return this.Ok(_applicantDetailsDao.FetchApplicantDetails());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("applicationlist")]

        public IActionResult fetchNewApplicationList()
        {
            try
            {
                NewApplication application = new NewApplication();
               

                return this.Ok(application.FetchNewApplication());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("fetchClient")]
        public IActionResult FetchClientDetails()
        {
            try
            {
                return this.Ok(_applicantDetailsDao.FetchClientDetails());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("fetchrejected")]
        public IActionResult FetchRejectedDetails()
        {
            try
            {
                return this.Ok(_applicantDetailsDao.FetchRejectedDetails());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
