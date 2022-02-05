using Fort.Data.Abstract;
using Fort.Dto.Request;
using Fort.Dto.Response;
using Fort.Services.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fort.Services.Concrete
{
    public class CountryServices : ICountryServices
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CountryServices(ICountryRepository countryRepository, IHttpContextAccessor httpContextAccessor)
        {
            _countryRepository = countryRepository;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<int> AddUserCountry(UserCountryRequest countryRequest)
        {
            countryRequest.UserAccountId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "UserAccountId")?.Value ?? "0");
            var result =await _countryRepository.AddUserCountry(countryRequest);
            return result;
        }

        public async Task<int> DeleteUserCountry(int countryId)
        {
            var result = await _countryRepository.DeleteUserCountry(countryId);
            return result;
        }

        public async Task<IEnumerable<UserCountryResponse>> GetUserCountry()
        {
            var result = await _countryRepository.GetUserCountry(Convert.ToInt32(_httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "UserAccountId")?.Value ?? "0"));
            return result;
        }

    }
}
