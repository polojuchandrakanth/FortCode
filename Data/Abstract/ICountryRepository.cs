using Fort.Dto.Request;
using Fort.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fort.Data.Abstract
{
    public interface ICountryRepository
    {
        Task<int> AddUserCountry(UserCountryRequest countryRequest);
        Task<int> DeleteUserCountry(int countryId);
        Task<IEnumerable<UserCountryResponse>> GetUserCountry(int UserAccountId);
    }
}
