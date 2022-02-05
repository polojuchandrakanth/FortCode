using Dapper;
using Fort.Data.Abstract;
using Fort.Data.Data;
using Fort.Dto.Request;
using Fort.Dto.Response;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Fort.Data.Concrete
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configruation)
          : base(configruation)
        {
        }

        public async Task<int> AddUser(UserRequest userRequest)
        {
            var result = await AddAsync<UserRequest>(userRequest);
            return result;
        }

        public async Task<UserResponse> AuthenticateUser(UserRequest userRequest)
        {
            var selectQuery = new StringBuilder();
            var paraSearch = new DynamicParameters();
            selectQuery.Append(@"SELECT UserAccountId
                                        ,Name
                                        ,Email
                                        ,Password AS PasswordHash
	                                FROM dbo.UserAccounts av WITH (NOLOCK)
	                                WHERE  email = @email");
            paraSearch.Add("@email", userRequest.Email);
            paraSearch.Add("@password", userRequest.Password);
            var result = await SelectData<UserResponse>(selectQuery.ToString(), paraSearch);
            return result;
        }
    }
}
