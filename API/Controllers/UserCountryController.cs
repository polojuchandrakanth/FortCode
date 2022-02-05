using Fort.Dto.Request;
using Fort.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Fort.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserCountryController : ControllerBase
    {
        private readonly ICountryServices _countryServices;
        public UserCountryController(ICountryServices countryServices)
        {
            _countryServices = countryServices;
        }


        [HttpPost("InsertCountry")]
        public async Task<IActionResult> AddUserCountry(UserCountryRequest countryRequest)
        {
            try
            {
                var result = await _countryServices.AddUserCountry(countryRequest);
                return result > 0 ? Ok("Success") : StatusCode(StatusCodes.Status422UnprocessableEntity, "Country & City Creation Failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry(int countryId)
        {
            try
            {
                var result = await _countryServices.DeleteUserCountry(countryId);
                return result > 0 ? Ok("Success") : StatusCode(StatusCodes.Status422UnprocessableEntity, "Country & City Delete Failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetUserCountry")]
        public async Task<IActionResult> GetUserCountry()
        {
            try
            {
                var result = await _countryServices.GetUserCountry();
                return result !=null ? Ok(result) : StatusCode(StatusCodes.Status422UnprocessableEntity, "Data Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
