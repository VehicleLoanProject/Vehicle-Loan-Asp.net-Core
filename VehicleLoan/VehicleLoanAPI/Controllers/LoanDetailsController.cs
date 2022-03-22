using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VehicleLoan.DataAccessLayer.Models;
using VehicleLoanDataAccessLayer.Repository.Abstraction;

namespace VehicleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanDetailsController : ControllerBase
    {
        private ILoanDetailsDao _loanDetailsDao = null;
        public LoanDetailsController(ILoanDetailsDao loanDetailsDao)
        {
            this._loanDetailsDao = loanDetailsDao;
        }
        [HttpGet]
        public IActionResult GetAllLoanDetails()
        {
            List<LoanDetailsModel> allLoanDetails = null;
            try
            {
                allLoanDetails = _loanDetailsDao.GetAllLoanDetails();
                return Ok(allLoanDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddLoanDetails([FromBody] LoanDetailsModel loanDetailsobj)
        {
            try
            {
                var result = _loanDetailsDao.AddLoanDetails(loanDetailsobj);
                return this.CreatedAtAction(
                    "AddLoanDetails", new
                    {
                        status = 201,
                        Response = result,
                        Data = loanDetailsobj

                    });
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.TargetSite);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteLoanDetails(int id)
        {
            try
            {
                var result = _loanDetailsDao.DeleteLoanRecord(id);
                return this.CreatedAtAction(
                    "DeleteLoanDetails", new
                    {
                        status = 201,
                        Response = result,
                        Data = id
                    }) ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message) ;
            }
        }
    }
}
