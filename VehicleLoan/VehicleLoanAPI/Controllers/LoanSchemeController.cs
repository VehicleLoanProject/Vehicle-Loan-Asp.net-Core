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
        // GET: api/<LoanSchemeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoanSchemeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoanSchemeController>
        [HttpPost]
        public void Post(LoanSchemeModel loanSchemeModel)
        {
            LoanSchemeDaoImpl loanSchemeDaoImpl = new LoanSchemeDaoImpl();
            bool result = loanSchemeDaoImpl.AddLoanScheme(loanSchemeModel);

        }

        // PUT api/<LoanSchemeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoanSchemeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
