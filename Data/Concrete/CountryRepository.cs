using Dapper;
using Fort.Data.Abstract;
using Fort.Data.Data;
using Fort.Dto.Request;
using Fort.Dto.Response;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fort.Data.Concrete
{
    public class CountryRepository : BaseRepository, ICountryRepository
    {
        public CountryRepository(IConfiguration configruation)
          : base(configruation)
        {
        }

        public async Task<int> AddUserCountry(UserCountryRequest countryRequest)
        {
            var result = await AddAsync(countryRequest);
            return result;
        }

        public async Task<int> DeleteUserCountry(int countryId)
        {
            var selectQuery = new StringBuilder();
            var paraSearch = new DynamicParameters();
            selectQuery.Append("DELETE FROM UserCountry WHERE UserCountryId = @countryId");
            paraSearch.Add("@countryId", countryId);
            var result = await ExecuteAsync(selectQuery.ToString(), paraSearch);
            return result;
        }

        public async Task<IEnumerable<UserCountryResponse>> GetUserCountry(int UserAccountId)
        {
            var selectQuery = new StringBuilder();
            var paraSearch = new DynamicParameters();
            selectQuery.Append("SELECT country, city from UserCountry WITH(NOLOCK) WHERE UserAccountId = @accountId");
            paraSearch.Add("@accountId", UserAccountId);
            var result = await SelectDataList<UserCountryResponse>(selectQuery.ToString(), paraSearch);
            return result;
        }
    }
}
