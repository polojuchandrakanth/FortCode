using Fort.Dto.Request;
using Fort.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fort.Services.Abstract
{
    public interface ICountryServices
    {
        Task<int> AddUserCountry(UserCountryRequest countryRequest);
        Task<int> DeleteUserCountry(int countryId);
        Task<IEnumerable<UserCountryResponse>> GetUserCountry();
    }
}
