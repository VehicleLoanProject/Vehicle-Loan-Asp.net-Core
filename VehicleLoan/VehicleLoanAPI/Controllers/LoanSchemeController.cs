using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleLoan.BusinessModels;
using VehicleLoan.DataAccessLayer.Repository.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleLoanAPI.Controllers
{
    [Route("api/LoanScheme")]
    [ApiController]
    public class LoanSchemeController : ControllerBase
    {
        [HttpGet]
        [Route("api/Scheme)")]

        public IActionResult GetLoanSchemes()
        {
            LoanSchemeDaoImpl loanSchemeDaoObj = new LoanSchemeDaoImpl();
            var fetchedData = loanSchemeDaoObj.FetchAllLoanSchemes();
            return this.Ok(fetchedData);
        }


        [HttpPost]
        public IActionResult AddLoanScheme([FromBody] LoanSchemeModel loanScheme)
        {

            LoanSchemeDaoImpl loanSchemeDaoObj = new LoanSchemeDaoImpl();
            var result = loanSchemeDaoObj.AddLoanScheme(loanScheme);
            return this.CreatedAtAction(
                "AddLoanScheme", new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = loanScheme
                }
                );
           

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteScheme(int id)
        {
            LoanSchemeDaoImpl loanSchemeDaoObj = new LoanSchemeDaoImpl();
            var result = loanSchemeDaoObj.DeleteLoanScheme(id);
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
        public IActionResult UpdateScheme(int id, [FromBody] LoanSchemeModel loanSchemeModel)
        {
            LoanSchemeDaoImpl loanSchemeDaoObj = new LoanSchemeDaoImpl();
            var result = loanSchemeDaoObj.UpdateLoanSchemeById(id, loanSchemeModel);
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



    

