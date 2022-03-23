using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleLoan.BusinessModels;
using VehicleLoan.DataAccessLayer.Repository.Implementation;
using VehicleLoan.DataAccessLayer.Repository.Abstraction;

namespace VehicleLoanAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IJwtTokenManager jwtTokenManager;
        public LoginController(IJwtTokenManager _manager)
        {
            this.jwtTokenManager = _manager;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ValidateUser([FromBody] UserRegistrationModel user)
        {
            AuthenticationDaoImpl authenticationDao = new AuthenticationDaoImpl();
            bool isAuthenticated = authenticationDao.AuthenticateUser(user);
            if (!isAuthenticated)
                return this.NotFound("User is not authenticated");

            //generate the Jwt and send as response to the user
            //get the secret key from appsettings.json file and convert it inot a byte array
            var tokenValue = this.jwtTokenManager.GenerateJwt(user);
            return this.Ok(new { token = tokenValue });

        }

        [HttpGet]
        //[Authorize]
        public string Index()
        {
            //string userName = HttpContext.User.Claims.First().Value;
            var headerValue = HttpContext.Request.Headers["Authorization"];
            if (headerValue.Count > 0)
            {
                var arrOfStrings = headerValue.ToString().Split(' ');
                var token = arrOfStrings[1];
                return "welcome to asp.net core auth, Admin " + token;
            }
            else
                return "welcome to asp.net core auth";
        }

        
    }
}
