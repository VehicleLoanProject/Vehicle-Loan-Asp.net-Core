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


        // GET: api/<ApplicantController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };

        }

        // GET api/<ApplicantController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApplicantController>
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
                Data = applicantDetailsModel
            }
            );
        }

        // PUT api/<ApplicantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApplicantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet]
        [Route("applicantDetails")]
        public IActionResult ApplicantDetails()
        {
            return this.Ok(_applicantDetailsDao.FetchApplicantDetails());
        }
        
    }
}
