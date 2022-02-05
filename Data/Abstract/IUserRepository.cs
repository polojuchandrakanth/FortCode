using Fort.Dto.Request;
using Fort.Dto.Response;
using System.Threading.Tasks;

namespace Fort.Data.Abstract
{
    public interface IUserRepository
    {
        Task<int> AddUser(UserRequest userRequest);
        Task<UserResponse> AuthenticateUser(UserRequest userRequest);
    }
}
