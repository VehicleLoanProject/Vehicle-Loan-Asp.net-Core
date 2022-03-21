using Microsoft.AspNetCore.Mvc;
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
           
            var result = _applicantDetailsDao.AddApplicantDetails(applicantDetailsModel);
            return this.CreatedAtAction(
            "AddApplicantDetails", new
            {
                Status = 201,
                Response = result,
                Data = applicantDetailsModel.CustomerId
            }
            );
        }

        [HttpDelete]
        [Route("{customerid}")]
        public IActionResult Delete(int customerid)
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

        [HttpGet]
        [Route("applicantDetails")]
        public IActionResult ApplicantDetails()
        {
            return this.Ok(_applicantDetailsDao.FetchApplicantDetails());
        }
        
    }
}
