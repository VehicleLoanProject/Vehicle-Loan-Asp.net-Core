using Microsoft.AspNetCore.Mvc;
using System;
using VehicleLoan.BusinessModels;
using VehicleLoan.DataAccessLayer.Repository.Abstraction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleLoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private IUserRegistrationDao _userDao = null;

            public UserRegistrationController(IUserRegistrationDao userDao)
            {
                this._userDao = userDao;

            }


            [HttpPost]
            [Route("addrecord")]
            public IActionResult AddUserRecord([FromBody] UserRegistrationModel userModel)
            {
                try
                {
                    var result = _userDao.AddRecord(userModel);
                    return this.CreatedAtAction(
                        "AddUserRecord", new
                        {
                            Status = 201,
                            Response = result,
                            Data = userModel
                        });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPut]
            public IActionResult UpdateUserRecord([FromBody] UserRegistrationModel record)
            {
                try
                {
                    var result = _userDao.UpdateRecord(record);

                    return this.CreatedAtAction("UpdateRecord", new
                    {
                        Status = 201,
                        Response = result,
                        Data = record
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpDelete]
            [Route("deleterecord/{userid}")]
            public IActionResult DeleteRecord(string userid)
            {

                try
                {
                    var result = _userDao.DeleteRecord(userid);

                    return this.CreatedAtAction(
                        "DeleteRecord", new
                        {
                            Status = 201,
                            Response = result,
                            Data = userid
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
