using Fort.Dto.Request;
using Fort.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fort.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("InsertUser")]
        public async Task<IActionResult> InsertUser(UserRequest userRequest)
        {
            try
            {
                var result = await _userServices.AddUser(userRequest);
                return result > 0 ? Ok("Success") : StatusCode(StatusCodes.Status422UnprocessableEntity, "User Creation Failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("AuthenticateUser")]
        public async Task<IActionResult> AuthenticateUser(UserRequest userRequest)
        {
            try
            {
                var result = await _userServices.AuthenticateUser(userRequest);
                return result != null ? Ok(result.Token) : StatusCode(StatusCodes.Status401Unauthorized, "User Authentication Failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
