using Fort.Dto.Request;
using Fort.Dto.Response;
using System.Threading.Tasks;

namespace Fort.Services.Abstract
{
    public interface IUserServices
    {
        Task<int> AddUser(UserRequest userRequest);
        Task<UserResponse> AuthenticateUser(UserRequest userRequest);
    }
}
