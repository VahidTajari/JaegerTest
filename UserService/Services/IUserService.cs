    
using User.Models;

namespace User.Services
{
    public interface IUserService
    {
        Task<List<Models.User>> GetUsersAsync();
        Task<ApiResult<Models.User>> AddUserAsync(string userName);
    }
}
