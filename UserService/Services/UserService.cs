using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using User.Models;
using User = User.Models.User;

namespace User.Services
{
    public class UserService:IUserService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly HttpClient _httpClient;
        private readonly AppConfig _appConfig;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext applicationDbContext, IHttpClientFactory httpClientFactory,
            IOptions<AppConfig> appConfig,IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _httpClient = httpClientFactory.CreateClient("github");
            _appConfig = appConfig.Value;
            _mapper = mapper;
        }

        public async Task<List<Models.User>> GetUsersAsync()=>await _applicationDbContext.Users.ToListAsync();
      

        public async Task<ApiResult<Models.User>> AddUserAsync(string username)
        {

            var result = new ApiResult<Models.User>();
            
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Login == username);

            if (user is null)
            {
                try
                {
                    var url = string.Format(_appConfig.Github.ProfileUrl, username);
                    var apiResult = await _httpClient.GetStringAsync(url);
                    var userDto = JsonSerializer.Deserialize<UserDto>(apiResult);
                    user = _mapper.Map<Models.User>(userDto);
                    await _applicationDbContext.Users.AddAsync(user);
                    await _applicationDbContext.SaveChangesAsync();
                    result.Result = user;
                    result.Message = "User successfully Created";
                    return result;
                }
                catch (Exception e)
                {
                    result.Message = "User not found";
                    return result;
                }
            }

            result.Message = "User already exist";
            result.Result = user;

            return result;

        }
    }
}
