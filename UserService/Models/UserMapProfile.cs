using AutoMapper;

namespace User.Models
{
    public class UserMapProfile:Profile
    {
        public UserMapProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}
