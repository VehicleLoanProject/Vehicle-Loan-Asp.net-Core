using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleLoan.BusinessModels;
using VehicleLoan.DataAccessLayer.Repository.Abstraction;
using VehicleLoan.DataAccessLayer.Repository.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleLoanAPI.Controllers
{
    [Route("api/LoanScheme")]
    [ApiController]
    public class LoanSchemeController : ControllerBase
    {
        private ILoanSchemeDao _loanScheneDao = null;

        public LoanSchemeController(ILoanSchemeDao loanScheneDao)
        {
            this._loanScheneDao = loanScheneDao;
        }

        [HttpGet]
        [Route("api/Scheme)")]

        public IActionResult GetLoanSchemes()
        {
            var fetchedData = _loanScheneDao.FetchAllLoanSchemes();
            return this.Ok(fetchedData);
        }


        [HttpPost]
        public IActionResult AddLoanScheme([FromBody] LoanSchemeModel loanScheme)
        {

            
            var result = _loanScheneDao.AddLoanScheme(loanScheme);
            return this.CreatedAtAction(
                "AddLoanScheme", new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = loanScheme
                }
                );
           

        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteScheme(int id)
        {
            
            var result = _loanScheneDao.DeleteLoanScheme(id);
            return this.CreatedAtAction(
                "DeletedLoanScheme",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = id
                }
                );
        }

        [HttpPut]
        public IActionResult UpdateScheme(int id, [FromBody] LoanSchemeModel loanSchemeModel)
        {
           
            var result = _loanScheneDao.UpdateLoanSchemeById(id, loanSchemeModel);
            return this.CreatedAtAction(
                "UpdateLoanScheme",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = loanSchemeModel
                }
                );
        }

    }
}



    

