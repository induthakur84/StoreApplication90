using AutoMapper;
using Order.Domain.Entites;
using Order.Dto.DTO.Request;
using Order.Dto.DTO.Response;

namespace Order.Data.Automapper
{
    public  class UserMapping: Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>()
                .ForMember(dest=>dest.Id, opt=>opt.Ignore());
        }
    }
}
